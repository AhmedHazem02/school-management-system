using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.service.Abstracts
{
    public interface IEmailServices
    {
        public Task<string> SendEmailAsync(string email,string Message);
    }
}
