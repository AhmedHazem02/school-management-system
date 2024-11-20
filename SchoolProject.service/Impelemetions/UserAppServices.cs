using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Org.BouncyCastle.Crypto;
using SchoolProject.Data.Entites.Identity;
using SchoolProject.infransturture.Data;
using SchoolProject.service.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.service.Impelemetions
{
    public class UserAppServices : IUserAppServices
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IEmailServices _emailServices;
        private readonly AppDbContext _dbContext;

        public UserAppServices(UserManager<AppUser> userManager
                                 ,IHttpContextAccessor httpContextAccessor
                                 , IEmailServices emailServices
                                 ,AppDbContext dbContext)
        {
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
            _emailServices = emailServices;
            _dbContext = dbContext;
        }
        public async Task<string> CreateUser(AppUser user, string Password)
        {
            var trans=await _dbContext.Database.BeginTransactionAsync();
            try
            {

                // if Email Exist
                if (await _userManager.FindByEmailAsync(user.Email) != null)
                    return "This Email Is Used";
                // if User Name Is Exist
                if (await _userManager.FindByNameAsync(user.UserName) != null)
                    return "This UserName Is Used";//BadRequest<string>("");


                // Create
                var Create = await _userManager.CreateAsync(user, Password);

                if (!Create.Succeeded) return Create.Errors.FirstOrDefault().Description;//BadRequest<string>();

                await _userManager.AddToRoleAsync(user, "User");

                // Send Confirme Password
                var Code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var ResqestAccessor = _httpContextAccessor.HttpContext.Request;
                var ResqestUrl = ResqestAccessor.Scheme + "://" + ResqestAccessor.Host + $"/api/V1/Authentication/ConfirmeEmail?UserId={user.Id}&Code={Code}";
                var Res = await _emailServices.SendEmailAsync(user.Email, ResqestUrl);               
                await trans.CommitAsync();
                return "Success"; 
            }
            catch (Exception ex)
            {
               await trans.RollbackAsync();
                return "Faild";
            }

        }
    }
}
