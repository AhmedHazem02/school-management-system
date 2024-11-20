using SchoolProject.Data.Entites.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.service.Abstracts
{
    public interface IUserAppServices
    {
        public Task<string> CreateUser(AppUser user, string Password);
    }
}
