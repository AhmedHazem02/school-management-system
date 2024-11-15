using Azure.Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.DTOs;
using SchoolProject.Data.Entites.Identity;
using SchoolProject.infransturture.Data;
using SchoolProject.service.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace SchoolProject.service.Impelemetions
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly AppDbContext _dbContext;

        public AuthorizationService(RoleManager<IdentityRole>roleManager
                                   ,UserManager<AppUser>userManager
                                   ,AppDbContext dbContext)
        {
             _roleManager = roleManager;
             _userManager = userManager;
             _dbContext = dbContext;
        }

        public async Task<string> AddRoleAsync(string roleName)
        {
            var IdentityRole = new IdentityRole();
            IdentityRole.Name = roleName;
            var Res= await _roleManager.CreateAsync(IdentityRole);
            if (Res.Succeeded) return "Success";
            return "Faild";
        }

        public async  Task<string> DeleteRoleAsync(string RoleId)
        {
             var res = await _roleManager.FindByIdAsync(RoleId);
            if (res is null) return "NotFound";
            var IfUsed = await _userManager.GetUsersInRoleAsync(res.Name);
            if (IfUsed is not null) return "Used";
            var Delete = await _roleManager.DeleteAsync(res);
            if (Delete.Succeeded) return "Succeed";
            else return Delete.Errors.FirstOrDefault().ToString();


        }

        public async Task<string> EditRoleAsync(EditRoleDTO request)
        {
             // if Exist
            var res= await _roleManager.FindByIdAsync(request.Id);
            if (res is null) return "NotFound";
            res.Name = request.Name;
            var Update=await _roleManager.UpdateAsync(res);
            if (Update.Succeeded) return "Succeed";
            else return Update.Errors.FirstOrDefault().ToString();
        }

        public async Task<List<IdentityRole>> GetListOfRoles()
        {
            return await _roleManager.Roles.ToListAsync();
        }

        public async Task<IdentityRole> GetRoleById(string RoleId)
        {
            return await _roleManager.FindByIdAsync(RoleId);

        }

        public async Task<bool> IsRoleExist(string roleName)
        {
            return await _roleManager.RoleExistsAsync(roleName);
        }

        public async Task<ManageUserRolesDTO> GetManageUserRole(AppUser user)
        {
            var response = new ManageUserRolesDTO();
            var Roles = new List<Roles>();
            var RoleUser = await _userManager.GetRolesAsync(user);
            var ListRole = await _roleManager.Roles.ToListAsync();
            response.UserId = user.Id;
            foreach (var role in ListRole)
            {
                var UserRule = new Roles();
                UserRule.RoleName = role.Name;
                UserRule.RoleId = role.Id;
                if (RoleUser.Contains(role.Name)) UserRule.HasRole = true;
                else UserRule.HasRole = false;
                Roles.Add(UserRule);
            }
            response.role = Roles;
            return response;
        }

        public async Task<string> UpdateUserRoles(UpdateRoleManagerDto request)
        {
            var transact= await _dbContext.Database.BeginTransactionAsync();
            try
            {
                
                var User = await _userManager.FindByIdAsync(request.UserId);
                if (User is null) return "UserNotFound";
                var UserRoles = await _userManager.GetRolesAsync(User);
                var ResRemove = await _userManager.RemoveFromRolesAsync(User, UserRoles);
                if (!ResRemove.Succeeded) return "FaildToRemoveRoles";
                var SelectRoles = request.role.Where(x => x.HasRole == true).Select(x => x.RoleName);
                var UpdateRoles = await _userManager.AddToRolesAsync(User, SelectRoles);
                if (!UpdateRoles.Succeeded) return "FaildToSuccess";
                await transact.CommitAsync();
                return "Success";
            }
            catch (Exception ex)
            {
                await transact.RollbackAsync();
                return "Faild";
            }
        }
    }
}
