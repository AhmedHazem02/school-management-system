using MediatR;
using SchoolProject.Core.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.User.Command.Models
{
    public class DeleteUserModel:IRequest<Response<string>>
    {
        public string UserName { get; set; }
        public DeleteUserModel(string User_Name)
        {
            UserName=User_Name;
        }
    }
}
