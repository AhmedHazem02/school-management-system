using MediatR;
using SchoolProject.Core.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Authorization.Commmand.Models
{
    public class DeleteRoleModel:IRequest<Response<string>>
    {
        public string RoleId { get; set; }
        public DeleteRoleModel(string Id) {
            RoleId = Id;        
        }
    }
}
