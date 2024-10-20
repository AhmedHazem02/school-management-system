using AutoMapper;
using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Data.Entites;
using SchoolProject.service.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Students.Commands.Handlers
{
    public class StudentCommandHandler : ResponseHandler,
                                          IRequestHandler<AddStudentCommand, Response<string>>,
                                          IRequestHandler<EditStudentCommand, Response<string>>,
                                          IRequestHandler<DeleteStudentCommand, Response<string>>
    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;

        public StudentCommandHandler(IStudentService studentService, IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }


        public async Task<Response<string>> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            var StudentMapping = _mapper.Map<Student>(request);

            var res=await _studentService.AddNewStudent(StudentMapping);
            if (res == "Sucess") return Created("Sucessed Add New Student");
            else return BadRequest<string>();


        }

        public async Task<Response<string>> Handle(EditStudentCommand request, CancellationToken cancellationToken)
        {
            // check if student Exits or not
            var Exist = await _studentService.GetStudentByIdWithoutIncludedAsync(request.id);
            if(Exist ==null) return NotFound<string>("The Student Not Exist");

             // mapping from EditStudentCommand To Student
             var StudentMapping=_mapper.Map(request,Exist);

            // Edit

            var EditStudent=await _studentService.EditStudentAsync(StudentMapping);
            if (EditStudent == "Success") return Success($"Edit Successful For Student ID = {StudentMapping.id}");
            return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            // check if student Exits or not
            var Student = await _studentService.GetStudentByIdWithoutIncludedAsync(request.Id);
            if (Student == null) return NotFound<string>("The Student Not Found");

            //Delete
            var res=await _studentService.DeleteStudentAsync(Student);
            if (res == "Success") return Deleted<string>($"Delete Successful  Student ID = {Student.id} Student Name = {Student.name}");
            return BadRequest<string>();


        }
    }
}
