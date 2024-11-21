using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Subjects.Queries.DTOs;
using SchoolProject.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Subjects.Queries.Models
{
    public class GetSubjectByIDModel:IRequest<Response<Subject>>
    {
        public int Id { get; set; }
        public GetSubjectByIDModel(int id)
        {
            Id = id;
        }
    }
}
