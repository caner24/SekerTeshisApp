using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using SekerTeshis.Entity;
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
        Task<(IdentityResult, string)> RegisterUser(UserDtoForRegister userForRegistrationDto);
        Task<bool> ValidateUser(UserDtoForManipulation userForAuthDto);
        SigningCredentials GetSignInCredentials();
        Task<List<Claim>> GetClaims();
        JwtSecurityToken GenerateTokenOptions(SigningCredentials signinCredentials,
             List<Claim> claims);
        string GenerateRefreshToken();
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
        Task<TokenDto> RefreshToken(TokenDto tokenDto);
        Task<string> GenerateEmailConfirmationTokenAsync(User user);
        Task<IdentityResult> ConfirmMailAsync(string mail, string token);
        Task<string> CreatePasswordTokenAsync(string mail);

        Task<IdentityResult> ResetPasswordAsync(string mail, string token, string password);
        Task<bool> IsAdminUser();
        string GetUserId();

    }
}
