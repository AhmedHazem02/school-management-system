using SchoolProject.Data.Entites.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.service.Abstracts
{
    public interface IAuthenticationServices
    {
        public Task<string>GetJWTToken(AppUser user);
    }
}
