using AutoMapper;
using SchoolProject.Core.Features.Subjects.Commands.Models;
using SchoolProject.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Mapping
{
    public class SubjectProfile:Profile
    {
        public SubjectProfile()
        {
            CreateMap<AddSubjectCommandModel,Subject>().ReverseMap();
            CreateMap<EditSubjectModel,Subject>().ReverseMap();
        }
    }
}
