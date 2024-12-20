﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.API.Base;
using SchoolProject.Core.Features.Authentication.Commands.Models;
using SchoolProject.Core.Features.Authentication.Queries.Models;
using SchoolProject.Core.Features.User.Command.Models;
using SchoolProject.Data.MetaDataApp;

namespace SchoolProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : AppBaseController
    {
        [HttpPost(Router.Authentication.SignIn)]
        public async Task<IActionResult> SignIn([FromForm] SignInCommandModel User)
        {
            return NewResult(await _mediator.Send(User)); 
        }

        [HttpGet(Router.Authentication.ConfirmeEmail)]
        public async Task<IActionResult> ConfirmeEmail([FromQuery]ConfirmEmailQueryModel Model)
        {
            return NewResult(await _mediator.Send(Model));
        }

        [HttpPost(Router.Authentication.SendRestPassword)]
        public async Task<IActionResult> ConfirmePassword([FromQuery] ConfirmeResetPasswordModel Model)
        {
            return NewResult(await _mediator.Send(Model));
        }

        [HttpGet(Router.Authentication.ConfirmeResetPassword)]
        public async Task<IActionResult> ResetPassword([FromForm] ConfirmeResetPasswordQueryModel Model)
        {
            return NewResult(await _mediator.Send(Model));
        }

        [HttpPost(Router.Authentication.ResetPassword)]
        public async Task<IActionResult> ResetPassword([FromQuery] ResetPasswordModel Model)
        {
            return NewResult(await _mediator.Send(Model));
        }
    }
}
