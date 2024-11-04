using MediatR;
using SchoolProject.Core.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Authentication.Commands.Models
{
    public class SignInCommandModel: IRequest<Response<string>>
    {
        public string UserName {  get; set; }
        public string Password { get; set; }
    }
}
