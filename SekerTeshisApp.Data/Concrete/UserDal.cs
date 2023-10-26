using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using SekerTeshis.Entity;
using SekerTeshis.Entity.DTO;
using SekerTeshis.Entity.Exception;
using SekerTeshisApp.Data.Abstract;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SekerTeshisApp.Data.Concrete
{
    public class UserDal : IUserDal
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
        private User? _user;
        public UserDal(
            IMapper mapper,
            UserManager<User> userManager,
            IConfiguration configuration)
        {
            _mapper = mapper;
            _userManager = userManager;
            _configuration = configuration;
        }
        public async Task<TokenDto> CreateToken(bool populateExp)
        {
            var signinCredentials = GetSignInCredentials();
            var claims = await GetClaims();
            var tokenOptions = GenerateTokenOptions(signinCredentials, claims);

            var refreshToken = GenerateRefreshToken();
            _user.RefreshToken = refreshToken;

            if (populateExp)
                _user.RefreshTokenExpiryTime = DateTime.Now.AddDays(7);

            await _userManager.UpdateAsync(_user);

            var accessToken = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            return new TokenDto()
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken
            };
        }

        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }

        public JwtSecurityToken GenerateTokenOptions(SigningCredentials signinCredentials, List<Claim> claims)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");

            var tokenOptions = new JwtSecurityToken(
                    issuer: jwtSettings["validIssuer"],
                    audience: jwtSettings["validAudience"],
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings["expires"])),
                    signingCredentials: signinCredentials);

            return tokenOptions;
        }

        public async Task<List<Claim>> GetClaims()
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, _user.UserName)
            };

            var roles = await _userManager
                .GetRolesAsync(_user);

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            return claims;
        }

        public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var secretKey = jwtSettings["secretKey"];

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSettings["validIssuer"],
                ValidAudience = jwtSettings["validAudience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;

            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters,
                out securityToken);

            var jwtSecurityToken = securityToken as JwtSecurityToken;
            if (jwtSecurityToken is null ||
                !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256,
                StringComparison.InvariantCultureIgnoreCase))
            {
                throw new SecurityTokenException("Invalid token.");
            }
            return principal;
        }

        public SigningCredentials GetSignInCredentials()
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var key = Encoding.UTF8.GetBytes(jwtSettings["secretKey"]);
            var secret = new SymmetricSecurityKey(key);
            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        public async Task<TokenDto> RefreshToken(TokenDto tokenDto)
        {
            var principal = GetPrincipalFromExpiredToken(tokenDto.AccessToken);
            var user = await _userManager.FindByNameAsync(principal.Identity.Name);

            if (user is null ||
                user.RefreshToken != tokenDto.RefreshToken ||
                user.RefreshTokenExpiryTime <= DateTime.Now)
                throw new RefreshTokenBadRequestException();

            _user = user;
            return await CreateToken(populateExp: false);
        }

        public async Task<IdentityResult> RegisterUser(UserDtoForRegister userForRegistrationDto)
        {
            var user = _mapper.Map<User>(userForRegistrationDto);

            var result = await _userManager
                .CreateAsync(user, userForRegistrationDto.Password);

            if (result.Succeeded)
                await _userManager.AddToRoleAsync(user, "DEFAULT");
            return result;
        }

        public async Task<bool> ValidateUser(UserDtoForManipulation userForAuthDto)
        {
            _user = await _userManager.FindByEmailAsync(userForAuthDto.Email);
            var result = (_user != null && await _userManager.CheckPasswordAsync(_user, userForAuthDto.Password));
            return result;
        }
    }
}
