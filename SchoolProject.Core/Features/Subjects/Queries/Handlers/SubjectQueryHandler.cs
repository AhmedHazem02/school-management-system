using AutoMapper;
using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Subjects.Commands.Models;
using SchoolProject.Core.Features.Subjects.Queries.DTOs;
using SchoolProject.Core.Features.Subjects.Queries.Models;
using SchoolProject.Data.Entites;
using SchoolProject.service.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Subjects.Queries.Handlers
{
    public class SubjectQueryHandler : ResponseHandler,
                                          IRequestHandler<GetListOfSubjectModel, Response<IReadOnlyList<Subject>>>,
                                          IRequestHandler<GetSubjectByIDModel, Response<Subject>>
    {
        private readonly ISubjectServices _subjectServices;
         

        public SubjectQueryHandler(ISubjectServices subjectServices )
        {
            _subjectServices = subjectServices;
    
        }
        public async Task<Response<IReadOnlyList<Subject>>> Handle(GetListOfSubjectModel request, CancellationToken cancellationToken)
        {
            var Res = await _subjectServices.GetSubjects();
            return Success(Res);
        }

        public async Task<Response<Subject>> Handle(GetSubjectByIDModel request, CancellationToken cancellationToken)
        {
            var Res=await _subjectServices.GetSubjectById(request.Id);
            if(Res==null)return NotFound<Subject>();
            return Success(Res);
        }
    }
}
