using Microsoft.AspNetCore.Identity;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using SchoolProject.Data.Entites.Identity;
using SchoolProject.Data.Helper;
using SchoolProject.Data.Helpers;
using SchoolProject.service.Abstracts;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.service.Impelemetions
{
    public class AuthenticationServices:IAuthenticationServices
    {
        private readonly JwtSettings _jwtSettings;
        private readonly UserManager<AppUser> _userManager;
        private readonly ConcurrentDictionary<string, RefreshToken> _UserRefreashToken;
        public AuthenticationServices(JwtSettings jwtSettings,UserManager<AppUser>userManager) {
            _jwtSettings = jwtSettings;
            _userManager = userManager;
            _UserRefreashToken = new ConcurrentDictionary<string, RefreshToken>();
        }

        public async Task<JwtAuthResult> GetJWTToken(AppUser user)
        {
            var roles=await _userManager.GetRolesAsync(user);
            var claims = GetClaims(user,roles.ToList());
            var jwtToken = new JwtSecurityToken(
                _jwtSettings.Issuer,
                _jwtSettings.Audience,
                claims,
                expires: DateTime.Now.AddDays(_jwtSettings.AccessTokenExpireDate),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtSettings.Secret)), SecurityAlgorithms.HmacSha256Signature));
            var accessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            var response = new JwtAuthResult();
            var refreshToken = GetRefreshToken(user.UserName); 
            response.refreshToken = refreshToken;
            response.AccessToken = accessToken;
            return response;
        }
        private RefreshToken GetRefreshToken(string username)
        {
            var refreshToken = new RefreshToken
            {
                ExpireAt = DateTime.Now.AddDays(_jwtSettings.RefreshTokenExpireDate),
                UserName = username,
                TokenString = GenerateRefreshToken()
            };
            _UserRefreashToken.AddOrUpdate(refreshToken.TokenString, refreshToken,(s,t)=>refreshToken);
            return refreshToken;
        }

        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            var randomNumberGenerate = RandomNumberGenerator.Create();
            randomNumberGenerate.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }

        public List<Claim> GetClaims(AppUser user,List<string>Roles)
        {

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name,user.UserName),
                new Claim(ClaimTypes.NameIdentifier,user.UserName),
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(nameof(UserClaimModel.PhoneNumber), user.PhoneNumber),
                 
            };
            foreach(var role in Roles)
              claims.Add(new Claim(ClaimTypes.Role,role));
            
            
           
            return claims;
        }

    }
}
