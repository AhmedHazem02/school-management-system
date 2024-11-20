using MediatR;
using SchoolProject.Core.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Authentication.Commands.Models
{
    public class ResetPasswordModel:IRequest<Response<string>>
    {
        public string Password { get; set; }
        public string ConfirmePassword {  get; set; }
        public string Email { get; set; }

    }
}
