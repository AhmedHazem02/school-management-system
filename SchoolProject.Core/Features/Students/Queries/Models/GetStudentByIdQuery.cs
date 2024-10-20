
using Azure;
using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Students.Queries.DTOs;
using SchoolProject.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Students.Queries.Models
{
    public class GetStudentByIdQuery : IRequest<Bases.Response<StudentDTO>>
    {
        public int id {  get; set; }

        public GetStudentByIdQuery(int Id) {
            id = Id;
        }
    }
}
