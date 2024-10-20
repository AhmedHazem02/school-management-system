using AutoMapper;
using AutoMapper.Configuration.Conventions;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Core.Features.Students.Queries.DTOs;
using SchoolProject.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Mapping
{
    public class StudentProfile:Profile
    {
        public StudentProfile() {
            CreateMap<Student, StudentDTO>()
                 .ForMember(x => x.DepartmentName, opt => opt.MapFrom(src => src.Department.DName));
            CreateMap<AddStudentCommand,Student>()
               .ForMember(x => x.DepartmentId, opt => opt.MapFrom(src => src.DepartmentId));
            CreateMap<EditStudentCommand, Student>()
               .ForMember(x => x.DepartmentId, opt => opt.MapFrom(src => src.DepartmentId))
               .ForMember(x => x.id, opt => opt.MapFrom(src => src.id));

        }
    }
}
