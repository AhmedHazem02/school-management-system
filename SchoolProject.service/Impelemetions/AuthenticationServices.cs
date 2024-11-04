using Microsoft.IdentityModel.Tokens;
using SchoolProject.Data.Entites.Identity;
using SchoolProject.Data.Helper;
using SchoolProject.Data.Helpers;
using SchoolProject.service.Abstracts;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.service.Impelemetions
{
    public class AuthenticationServices:IAuthenticationServices
    {
        private readonly JwtSettings _jwtSettings;

        public AuthenticationServices(JwtSettings jwtSettings) {
            _jwtSettings = jwtSettings;
        }

        public  Task<string> GetJWTToken(AppUser user)
        {
            var claims = new List<Claim>()
            {
                new Claim(nameof(UserClaimModel.UserName), user.UserName),
                new Claim(nameof(UserClaimModel.Email), user.Email),
                new Claim(nameof(UserClaimModel.PhoneNumber), user.PhoneNumber)
            };

            var JwtToken = new JwtSecurityToken(
                _jwtSettings.Issuer,
                _jwtSettings.Audience,
                claims,
                expires:DateTime.Now.AddMinutes(3),
                signingCredentials:new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtSettings.Secret)),
                SecurityAlgorithms.HmacSha256));
            var accessToken = new JwtSecurityTokenHandler().WriteToken(JwtToken);
            return Task.FromResult(accessToken);


        }
    }
}
