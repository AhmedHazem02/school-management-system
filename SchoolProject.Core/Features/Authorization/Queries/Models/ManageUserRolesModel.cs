using Azure.Core;
using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Data.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Authorization.Queries.Models
{
    public class ManageUserRolesModel:IRequest<Response<ManageUserRolesDTO>>
    {
        public string UserId { get; set; }
        public ManageUserRolesModel(string id) {
            UserId= id;
        }
    }
}
