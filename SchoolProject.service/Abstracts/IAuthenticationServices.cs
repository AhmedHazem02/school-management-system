using SchoolProject.Data.Entites.Identity;
using SchoolProject.Data.Helpers;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.service.Abstracts
{
    public interface IAuthenticationServices
    {
        public Task<JwtAuthResult> GetJWTToken(AppUser user);
        public Task<string> ConfirmeEmail(string UserId,string Code);
        public Task<string> ConfirmePassword(string Email);
        public Task<string> ConfirmeResetPassword(string Email, string Code);
        public Task<string> ResetPassword(string Email,string Password);


    }
}
