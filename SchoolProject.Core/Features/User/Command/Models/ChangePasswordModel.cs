using MediatR;
using SchoolProject.Core.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.User.Command.Models
{
    public class ChangePasswordModel : IRequest<Response<string>>
    {
        public string Id {  get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; } 
        public string ConfirmPassword { get; set;}
    }
}
