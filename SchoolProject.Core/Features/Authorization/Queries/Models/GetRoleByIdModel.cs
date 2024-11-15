using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Authorization.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Authorization.Queries.Models
{
    public class GetRoleByIdModel:IRequest<Response<GetRoleDTO>>
    {
        public  string RoleId {  get; set; }
        public GetRoleByIdModel(string id)
        {
           RoleId = id;
        }
    }
}
