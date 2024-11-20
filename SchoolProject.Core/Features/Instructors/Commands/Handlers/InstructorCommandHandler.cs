using AutoMapper;
using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Instructors.Commands.Models;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Data.Entites;
using SchoolProject.service.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Instructors.Commands.Handlers
{
    public class InstructorCommandHandler : ResponseHandler,
                                          IRequestHandler<AddInstructorModel, Response<string>>
    {
        private readonly IInstructorServices _instructorServices;
        private readonly IMapper _mapper;

        public InstructorCommandHandler(IInstructorServices instructorServices,IMapper mapper)
        {
            _instructorServices = instructorServices;
            _mapper = mapper;
        }
        public async Task<Response<string>> Handle(AddInstructorModel request, CancellationToken cancellationToken)
        {
             //mapping
              var InsMapping = _mapper.Map<Instructor>(request); 
             var res = await _instructorServices.AddInstructorAsync(InsMapping);
             if (res == "Success") return Created("");
            return BadRequest<string>("Faild");
        }
    }
}
