using AutoMapper;
using SchoolProject.Core.Features.Instructors.Commands.Models;
using SchoolProject.Core.Features.Instructors.Queries.DTOs;
using SchoolProject.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Mapping
{
    public class InstructorProfile:Profile
    {
        public InstructorProfile()
        {
            CreateMap<AddInstructorModel,Instructor>().ReverseMap();
            CreateMap<Instructor,InstructorDto>().ReverseMap();
        }
    }
}
