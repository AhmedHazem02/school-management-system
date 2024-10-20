using AutoMapper;
using Azure.Core;
using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Department.Query.DTOs;
using SchoolProject.Core.Features.Department.Query.Models;
using SchoolProject.infransturture.Repository.Abstruct;
using SchoolProject.service.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Department.Query.Handlers
{
    public class DepartmentHandler : ResponseHandler, IRequestHandler<GetDepartmentById, Response<DepartmentDto>>
    {
        private readonly IMapper _mapper;
        private readonly IDepartmentService _departmentService;

        public DepartmentHandler(IMapper mapper,IDepartmentService departmentService) {
            _mapper = mapper;
            _departmentService = departmentService;
        }
        public async Task<Response<DepartmentDto>> Handle(GetDepartmentById request, CancellationToken cancellationToken)
        {
            var res = await _departmentService.GetDepartmentByIdAsync(request.Id);
            if (res == null) return NotFound<DepartmentDto>("The Department Not Found");
            var DeptMapping=_mapper.Map<DepartmentDto>(res);
            return Success(DeptMapping);
        }
    }
}
