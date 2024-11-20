using AutoMapper;
using SchoolProject.Core.Features.Department.Commands.Models;
using SchoolProject.Core.Features.Department.Query.DTOs;
using SchoolProject.Data.Entites;


namespace SchoolProject.Core.Mapping
{
    public class DepartmentProfile:Profile
    {
        public DepartmentProfile()
        {
            CreateMap<Department, DepartmentDto>()
                .ForMember(dest => dest.ManagerName, opt => opt.MapFrom(src => src.Instructor.Name))
                .ForMember(dest => dest.InstructorList, opt => opt.MapFrom(src => src.Instructors))
                .ForMember(dest => dest.SubjectList, opt => opt.MapFrom(src => src.DepartmentSubjects))
                .ForMember(dest => dest.StudentList, opt => opt.MapFrom(src => src.Students));

            CreateMap<DepartmentSubject, SubjectResponse>()
                .ForMember(dest=>dest.SubjectName,opt=>opt.MapFrom(src=>src.Subject.SubjectName));
            CreateMap<Student, StudentResponse>()
                .ForMember(dest => dest.name, opt => opt.MapFrom(src => src.name));

            CreateMap<Instructor, InstructorResponse>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

            CreateMap<EditDepartmentModel, Department>()
                .ForMember(dest => dest.DName, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.DeptId))
                .ReverseMap();

            CreateMap<AddDepartmentModel, Department>()
               .ForMember(dest => dest.DName, opt => opt.MapFrom(src => src.Name))
               .ReverseMap();

        }
    }
}
