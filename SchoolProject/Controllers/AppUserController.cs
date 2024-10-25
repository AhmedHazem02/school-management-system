using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.API.Base;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Core.Features.User.Command.Models;
using SchoolProject.Data.MetaDataApp;

namespace SchoolProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserController : AppBaseController
    {
        [HttpPost(Router.StudentRouting.Create)]
        public async Task<IActionResult> CreateNewUser([FromBody] AddUser User)
        {
            return NewResult(await _mediator.Send(User));
        }
    }
}
