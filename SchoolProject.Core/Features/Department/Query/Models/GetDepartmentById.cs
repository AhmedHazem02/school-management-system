using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Department.Query.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Department.Query.Models
{
    public  class GetDepartmentById:IRequest<Response<DepartmentDto>>
    {
        public int Id { get; set; }

        public GetDepartmentById(int id)
        {
            Id=id;
        }
    }
}
