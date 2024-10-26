using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.User.Queries.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.User.Queries.Models
{
    public class GetUserByUserName:IRequest<Response<UserDTO>>
    {
        public string UserName { get; set; }
        public GetUserByUserName(string User_Name)
        {
            UserName=User_Name;
        }
    }
}
