using AutoMapper;
using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Instructors.Queries.DTOs;
using SchoolProject.Core.Features.Instructors.Queries.Models;
using SchoolProject.service.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Instructors.Queries.Handlers
{
    public class InstructorQueryHandler : ResponseHandler,
                                          IRequestHandler<GetListOfInstructorModel, Response<List<InstructorDto>>>
    {
        private readonly IInstructorServices _instructorServices;
        private readonly IMapper _mapper;

        public InstructorQueryHandler(IInstructorServices instructorServices,IMapper mapper)
        {
            _instructorServices = instructorServices;
            _mapper = mapper;
        }
        public async Task<Response<List<InstructorDto>>> Handle(GetListOfInstructorModel request, CancellationToken cancellationToken)
        {
            var instructors = await _instructorServices.GetListOfInstructor();      
            //mapping 
            var InstructorsMapping=_mapper.Map<List<InstructorDto>>(instructors);   
            return Success(InstructorsMapping);
        }
    }
}
