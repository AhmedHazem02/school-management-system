using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Instructors.Queries.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Instructors.Queries.Models
{
    public class GetInstructorByIdModel:IRequest<Response<InstructorDto>>
    {
        public int Id { get; set; }
        public GetInstructorByIdModel(int id)
        {
            Id=id;
        }
    }
}
