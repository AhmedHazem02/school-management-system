using MediatR;
using SchoolProject.Core.Bases;
namespace SchoolProject.Core.Features.Instructors.Commands.Models
{
    public class AddInstructorModel:IRequest<Response<string>>
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string? Position { get; set; }

        public int? SuperVisorId { get; set; }

        public decimal Salary { get; set; }
        public int DepartmentId {  get; set; }
    }
}
