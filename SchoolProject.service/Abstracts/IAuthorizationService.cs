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
    }
}
