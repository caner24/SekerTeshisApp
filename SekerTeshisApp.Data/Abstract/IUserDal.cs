using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using SekerTeshis.Entity.DTO;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SekerTeshisApp.Data.Abstract
{
    public interface IUserDal
    {
        Task<TokenDto> CreateToken(bool populateExp);

        Task<IdentityResult> RegisterUser(UserDtoForRegister userForRegistrationDto);

        Task<bool> ValidateUser(UserDtoForManipulation userForAuthDto);

        SigningCredentials GetSignInCredentials();

        Task<List<Claim>> GetClaims();
        JwtSecurityToken GenerateTokenOptions(SigningCredentials signinCredentials,
             List<Claim> claims);

        string GenerateRefreshToken();
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
        Task<TokenDto> RefreshToken(TokenDto tokenDto);

        Task<string> GenerateEmailConfirmationTokenAsync();

    }
}
