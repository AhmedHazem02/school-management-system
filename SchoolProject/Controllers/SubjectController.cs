using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.API.Base;
using SchoolProject.Core.Features.Authentication.Commands.Models;
using SchoolProject.Core.Features.Subjects.Commands.Models;
using SchoolProject.Core.Features.Subjects.Queries.Models;
using SchoolProject.Data.MetaDataApp;

namespace SchoolProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : AppBaseController
    {
        [HttpPost(Router.Subject.AddSubject)]
        public async Task<IActionResult> AddSubject([FromBody] AddSubjectCommandModel subject)
        {
            return NewResult(await _mediator.Send(subject));
        }

        [HttpDelete(Router.Subject.DeleteSubject)]
        public async Task<IActionResult> DeleteSubject([FromRoute] int id)
        {
            return NewResult(await _mediator.Send(new DeleteSubjectModel(id)));
        }
        [HttpPut(Router.Subject.EditSubject)]
        public async Task<IActionResult> EditSubject([FromBody] EditSubjectModel subject)
        {
            return NewResult(await _mediator.Send(subject));
        }

        [HttpGet(Router.Subject.GetSubjectById)]
        public async Task<IActionResult> GetSubjectById([FromRoute] int id)
        {
            return NewResult(await _mediator.Send(new GetSubjectByIDModel(id)));
        }

        [HttpGet(Router.Subject.GetSubjects)]
        public async Task<IActionResult> GetSubjects()
        {
            return NewResult(await _mediator.Send(new GetListOfSubjectModel()));
        }
    }
}
