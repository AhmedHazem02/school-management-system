using AutoMapper;
using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Subjects.Commands.Models;
using SchoolProject.Core.Features.User.Command.Models;
using SchoolProject.Data.Entites;
using SchoolProject.service.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Subjects.Commands.Handlers
{
    public class SubjectHandlerCommand : ResponseHandler,
                                          IRequestHandler<AddSubjectCommandModel, Response<string>>,
                                          IRequestHandler<EditSubjectModel, Response<string>>,
                                          IRequestHandler<DeleteSubjectModel, Response<string>>
    {
        private readonly ISubjectServices _subjectServices;
        private readonly IMapper _mapper;

        public SubjectHandlerCommand(ISubjectServices subjectServices,IMapper mapper)
        {
              _subjectServices = subjectServices;
              _mapper = mapper;
        }

        public async Task<Response<string>> Handle(AddSubjectCommandModel request, CancellationToken cancellationToken)
        {
            var SubjectMapping = _mapper.Map<Subject>(request);
            var Res=await _subjectServices.AddSubject(SubjectMapping);
            return Created<string>(Res); 
        }

        public async Task<Response<string>> Handle(EditSubjectModel request, CancellationToken cancellationToken)
        {
            var SubjectMapping = _mapper.Map<Subject>(request);
            var res= await _subjectServices.EditCourse(SubjectMapping);
            if (res == "NotFound") return NotFound<string>();
            else if (res == "Faild") return BadRequest<string>();
            else return Success<string>(res);
        }

        public async Task<Response<string>> Handle(DeleteSubjectModel request, CancellationToken cancellationToken)
        {
            var res = await _subjectServices.DeleteSubject(request.Id);
            if (res == "NotFound") return NotFound<string>();
            else if (res == "Faild") return BadRequest<string>();
            else return Deleted<string>(res);
           
        }
    }
}
