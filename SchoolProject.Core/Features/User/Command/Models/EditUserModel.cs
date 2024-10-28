using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.User.Queries.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.User.Command.Models
{
    public class EditUserModel : IRequest<Response<string>>
    {
        public string DisplayName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
