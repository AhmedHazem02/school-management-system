using MediatR;
using SchoolProject.Core.Bases;

namespace SchoolProject.Core.Features.Department.Commands.Models
{
    public class AddDepartmentModel : IRequest<Response<string>>
    {
         
        public string Name { get; set; }
        public int? Ins_Manager { get; set; }

    }
}
