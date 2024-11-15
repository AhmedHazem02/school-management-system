using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.API.Base;
using SchoolProject.Core.Features.Email.Commands.Models;
using SchoolProject.Core.Features.User.Command.Models;
using SchoolProject.Data.MetaDataApp;

namespace SchoolProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : AppBaseController
    {
        [HttpPost(Router.Email.SendEmail)]
        public async Task<IActionResult> SendEmail([FromQuery] SendEmailModel model)
        {
            return NewResult(await _mediator.Send(model));
        }
    }
}
