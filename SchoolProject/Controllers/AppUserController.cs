﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.API.Base;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Core.Features.User.Command.Models;
using SchoolProject.Core.Features.User.Queries.Models;
using SchoolProject.Data.MetaDataApp;

namespace SchoolProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserController : AppBaseController
    {
        [HttpPost(Router.AppUserRouting.Create)]
        public async Task<IActionResult> CreateNewUser([FromBody] AddUser User)
        {
            return NewResult(await _mediator.Send(User));
        }

        [HttpGet(Router.AppUserRouting.List)]
        public async Task<IActionResult> GetUsers([FromQuery] GetUsersListPagination Users)
        {
            return Ok(await _mediator.Send(Users));
        }

        [HttpGet(Router.AppUserRouting.GetUserByUserName)]
        public async Task<IActionResult> GetUserByUserName([FromRoute]string UserName)
        {
            return Ok(await _mediator.Send(new GetUserByUserName(UserName)));
        }

        [HttpPut(Router.AppUserRouting.Edit)]
        public async Task<IActionResult> EditUser([FromBody] EditUserModel User)
        {
            return NewResult(await _mediator.Send(User));
        }

        [HttpDelete(Router.AppUserRouting.DeleteUser)]
        public async Task<IActionResult> DeleteUser([FromRoute] string UserName)
        {
            return NewResult(await _mediator.Send(new DeleteUserModel(UserName)));
        }


        [HttpPut(Router.AppUserRouting.ChangePassword)]
        public async Task<IActionResult> ChangeUserPassword([FromBody] ChangePasswordModel Model)
        {
            return NewResult(await _mediator.Send(Model));
        }


    }
}
