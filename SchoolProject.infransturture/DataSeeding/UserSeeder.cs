using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entites.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.infransturture.DataSeeding
{
    public static class UserSeeder
    {
        public static async Task SeedAsync(UserManager<AppUser> _userManager)
        {
            var UsersCount= await _userManager.Users.CountAsync();
            if (UsersCount <= 0)
            {
                var defaultUser = new AppUser()
                {
                    UserName = "admin",
                    Email = "admin123@gmail.com",
                    DisplayName = "Admin",
                    PhoneNumber = "122",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                };
                await _userManager.CreateAsync(defaultUser,"Admin@123");
                await _userManager.AddToRoleAsync(defaultUser, "Admin");
            }
        }
    }
}
