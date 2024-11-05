using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.API.Base;
using SchoolProject.Core.Features.Authorization.Commmand.Models;
using SchoolProject.Core.Features.User.Command.Models;
using SchoolProject.Data.MetaDataApp;

namespace SchoolProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : AppBaseController
    {
        [Authorize]
        [HttpPost(Router.Authorization.Create)]
        public async Task<IActionResult> CreateNewRole([FromForm] AddRoleModelCommand command)
        {
            return NewResult(await _mediator.Send(command));
        }

    }
}
