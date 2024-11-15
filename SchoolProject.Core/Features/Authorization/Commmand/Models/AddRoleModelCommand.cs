using MediatR;
using SchoolProject.Core.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Authorization.Commmand.Models
{
    public class AddRoleModelCommand:IRequest<Response<string>>
    {
        public string RoleName {  get; set; }
    }
}
