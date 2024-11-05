using Microsoft.AspNetCore.Identity;
using SchoolProject.Data.Entites.Identity;
using SchoolProject.service.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.service.Impelemetions
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public AuthorizationService(RoleManager<IdentityRole>roleManager)
        {
             _roleManager = roleManager;
        }

        public async Task<string> AddRoleAsync(string roleName)
        {
            var IdentityRole = new IdentityRole();
            IdentityRole.Name = roleName;
            var Res= await _roleManager.CreateAsync(IdentityRole);
            if (Res.Succeeded) return "Success";
            return "Faild";
        }

        public async Task<bool> IsRoleExist(string roleName)
        {
            return await _roleManager.RoleExistsAsync(roleName);
        }
    }
}
