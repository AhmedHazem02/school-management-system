using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.API.Base;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Core.Features.Students.Queries.Models;
using SchoolProject.Data.MetaDataApp;

namespace SchoolProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : AppBaseController
    {
      
        [HttpGet(Router.StudentRouting.List)]
        public async Task<IActionResult> GetStudentList()
        {
             return NewResult(await _mediator.Send(new GetStudentListQuery()));
        }

        [HttpGet(Router.StudentRouting.Pagination)]
        public async Task<IActionResult> GetStudentListPagination([FromQuery] GetStudentListPagination pagination)
        {
            return Ok(await _mediator.Send(pagination));
        }

        [Authorize]
        [HttpGet(Router.StudentRouting.GetById)]
        public async Task<IActionResult> GetStudentById([FromRoute] int Id)
        {
            return NewResult(await _mediator.Send(new GetStudentByIdQuery(Id)));
        }

        [Authorize]
        [HttpPost(Router.StudentRouting.Create)]
        public async Task<IActionResult> CreateNewStudent([FromBody] AddStudentCommand student)
        {
            return NewResult(await _mediator.Send(student));
        }
        [HttpPut(Router.StudentRouting.Edit)]
        public async Task<IActionResult> EditStudent([FromBody] EditStudentCommand student)
        {
            return NewResult(await _mediator.Send(student));
        }

        [HttpDelete(Router.StudentRouting.Delete)]
        public async Task<IActionResult> DeleteStudent([FromRoute] int id)
        {
            return NewResult(await _mediator.Send(new DeleteStudentCommand(id)));
        }

    }
}
