using AutoMapper;
using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Department.Commands.Models;
using SchoolProject.service.Abstracts;

namespace SchoolProject.Core.Features.Department.Commands.Handlers
{
    public class DepartmentCommandHandler : ResponseHandler,
                                          IRequestHandler<EditDepartmentModel, Response<string>>,
                                          IRequestHandler<AddDepartmentModel, Response<string>>
    {
        private readonly IDepartmentService _departmentService;
        private readonly IMapper _mapper;

        public DepartmentCommandHandler(IDepartmentService departmentService,IMapper mapper)
        {
           _departmentService = departmentService;
           _mapper = mapper;
        }
        public async Task<Response<string>> Handle(EditDepartmentModel request, CancellationToken cancellationToken)
        {
            var Dept = await _departmentService.GetDepartmentByIdAsyncNotInclude(request.DeptId);
            if(Dept ==null)return NotFound<string>();
            //Mapping
            var DeptMapping = _mapper.Map(request,Dept);
            var Res = await _departmentService.EditDepartment(DeptMapping);
            if(Res=="Success") return Success("");
            return BadRequest<string>("Faild");
        }

        public async Task<Response<string>> Handle(AddDepartmentModel request, CancellationToken cancellationToken)
        {
            var DeptMapping = _mapper.Map <Data.Entites.Department>(request);
            var Res = await _departmentService.AddDepartment(DeptMapping);
            if (Res == "Success") return Created("");
            return BadRequest<string>("Faild");
            
        }
    }
}
