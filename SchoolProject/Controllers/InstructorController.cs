using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.API.Base;
using SchoolProject.Core.Features.Instructors.Commands.Models;
using SchoolProject.Core.Features.Instructors.Queries.Models;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Data.MetaDataApp;

namespace SchoolProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorController : AppBaseController
    {
        [HttpPost(Router.Instructor.Create)]
        public async Task<IActionResult> CreateNewInstructor([FromBody]AddInstructorModel instructor)
        {
            return NewResult(await _mediator.Send(instructor));
        }

        [HttpGet(Router.Instructor.GetAllInstructor)]
        public async Task<IActionResult> GetAllInstructor()
        {
            return NewResult(await _mediator.Send(new GetListOfInstructorModel()));
        }
    }
}
