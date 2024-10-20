using AutoMapper;
using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Students.Queries.DTOs;
using SchoolProject.Core.Features.Students.Queries.Models;
using SchoolProject.Core.Pagination;
using SchoolProject.Data.Entites;
using SchoolProject.service.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Students.Queries.Handlers
{
    public class StudentHandler : ResponseHandler,
                                 IRequestHandler<GetStudentListQuery, Response<List<StudentDTO>>>,
                                 IRequestHandler<GetStudentByIdQuery, Response<StudentDTO>>,
                                 IRequestHandler<GetStudentListPagination, PaginatedResult<StudentListPaginationDTO>>


    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;

        public StudentHandler(IStudentService studentService,IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }
        public async Task<Response<List<StudentDTO>>> Handle(GetStudentListQuery request, CancellationToken cancellationToken)
        {
            var Students =await _studentService.GetStudentsAsync();
            var StudentMapping=_mapper.Map<List<StudentDTO>>(Students);
            return Success(StudentMapping);

        }

        public async Task<Response<StudentDTO>> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            var student = await _studentService.GetStudentByIdAsync(request.id);
            if (student == null) return NotFound<StudentDTO>("Object Not Found");
            var studentMapping = _mapper.Map<StudentDTO>(student);
             return Success(studentMapping);
            
        }

        public async Task<PaginatedResult<StudentListPaginationDTO>> Handle(GetStudentListPagination request, CancellationToken cancellationToken)
        {
            Expression<Func<Student, StudentListPaginationDTO>>
               expression = e => new StudentListPaginationDTO(e.id, e.name, e.Address, e.Department.DName);
            var q = _studentService.GetStudentsQuerable();

            // If Need Filter
            /*
            var Filter = _studentService.GetStudentsSearchQuerable(request.Search);
            var res = await Filter.Select(expression).ToPaginatedListAsync(request.PagerSize, request.PagerSize);
            */

            var res = await q.Select(expression).ToPaginatedListAsync(request.PagerSize, request.PagerSize);
            return res;
        }
    }
}
