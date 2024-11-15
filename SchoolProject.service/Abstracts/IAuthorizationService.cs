using Microsoft.AspNetCore.Identity;
using SchoolProject.Data.DTOs;
using SchoolProject.Data.Entites.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.service.Abstracts
{
    public interface IAuthorizationService
    {
        public Task<string>AddRoleAsync(string roleName);
        public Task<bool> IsRoleExist(string roleName);

        public Task<string> EditRoleAsync(EditRoleDTO request);
        public Task<string> DeleteRoleAsync(string RoleId);
        public Task<IdentityRole> GetRoleById(string RoleId);
        public Task<List<IdentityRole>> GetListOfRoles();

        public Task<ManageUserRolesDTO> GetManageUserRole(AppUser user);
        public Task<string>UpdateUserRoles(UpdateRoleManagerDto request);

    }
}
