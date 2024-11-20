using MediatR;
using SchoolProject.Core.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Department.Commands.Models
{
    public class EditDepartmentModel:IRequest<Response<string>>
    {
        public int DeptId {  get; set; }
        public string Name { get; set; }
        public int? Ins_Manager {  get; set; } 
        
    }
}
