using EntityFrameworkCore.EncryptColumn.Interfaces;
using EntityFrameworkCore.EncryptColumn.Util;
using Microsoft.AspNetCore.Identity;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using SchoolProject.Data.Entites.Identity;
using SchoolProject.Data.Helper;
using SchoolProject.Data.Helpers;
using SchoolProject.infransturture.Data;
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
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;

namespace SchoolProject.service.Impelemetions
{
    public class AuthenticationServices:IAuthenticationServices
    {
        private readonly JwtSettings _jwtSettings;
        private readonly UserManager<AppUser> _userManager;
        private readonly IEmailServices _emailServices;
        private readonly AppDbContext _appDbContext;
        private readonly IEncryptionProvider _encryptionProvider;
        private readonly ConcurrentDictionary<string, RefreshToken> _UserRefreashToken;
        
        public AuthenticationServices(JwtSettings jwtSettings,UserManager<AppUser>userManager
                                      ,IEmailServices emailServices,AppDbContext appDbContext) {
            _jwtSettings = jwtSettings;
            _userManager = userManager;
            _emailServices = emailServices;
            _appDbContext = appDbContext;
            _UserRefreashToken = new ConcurrentDictionary<string, RefreshToken>();
            _encryptionProvider = new GenerateEncryptionProvider("8487e014e5e244f2ab85af391ea165aa");
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

        public async Task<string> ConfirmeEmail(string UserId, string Code)
        {
            if (UserId == null || Code == null) return "Invalid";
            var User=await _userManager.FindByIdAsync(UserId);
            var Res = await _userManager.ConfirmEmailAsync(User, Code);
            if (Res.Succeeded) return "Success";
            return "Faild";
        }

        public async Task<string> ConfirmePassword(string Email)
        {
            var Trans = await _appDbContext.Database.BeginTransactionAsync();
            try
            {
                var User = await _userManager.FindByEmailAsync(Email);
                if (User == null) return "Not Found";
                Random random = new Random();
                string RandomNumber = random.Next(0, 100000).ToString("D6");
                User.Code = RandomNumber;
                var UpdateUser = await _userManager.UpdateAsync(User);
                if (!UpdateUser.Succeeded) return "Faild To Update User";
                var Message = "Code To Reset Password : " + User.Code;
                await _emailServices.SendEmailAsync(Email, Message);
                await Trans.CommitAsync();
                return "Success";
            }
            catch (Exception ex)
            {
                await Trans.RollbackAsync();
                return "Faild";
            }
        }

        public async Task<string> ConfirmeResetPassword(string Email, string Code)
        {

            var User = await _userManager.FindByEmailAsync(Email);
            if (User == null) return "Not Found";
            var UserCode=_encryptionProvider.Decrypt(User.Code);
            if (UserCode == Code) return "Success";
            return "Faild";
        }

        public async Task<string> ResetPassword(string Email, string Password)
        {
            var Trans = await _appDbContext.Database.BeginTransactionAsync();
            try
            {
                var User = await _userManager.FindByEmailAsync(Email);
                if (User == null) return "Not Found";
                await _userManager.RemovePasswordAsync(User);
                await _userManager.AddPasswordAsync(User, Password);
                await Trans.CommitAsync();
                return "Success";
            }
            catch (Exception ex)
            {
                await Trans.RollbackAsync();
                return "Faild";
            }
        }
    }
}
