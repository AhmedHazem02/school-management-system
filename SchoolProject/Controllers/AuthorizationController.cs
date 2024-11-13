using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.API.Base;
using SchoolProject.Core.Features.Authorization.Commmand.Models;
using SchoolProject.Core.Features.Authorization.Queries.Models;
using SchoolProject.Core.Features.User.Command.Models;
using SchoolProject.Data.MetaDataApp;

namespace SchoolProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles ="Admin")]
    public class AuthorizationController : AppBaseController
    {
        [HttpPost(Router.Authorization.Create)]
        public async Task<IActionResult> CreateNewRole([FromForm] AddRoleModelCommand command)
        {
            return NewResult(await _mediator.Send(command));
        }

        [HttpPost(Router.Authorization.Edit)]
        public async Task<IActionResult>EditRole([FromForm] EditRoleModel command)
        {
            return NewResult(await _mediator.Send(command));
        }


        [HttpDelete(Router.Authorization.Delete)]
        public async Task<IActionResult> DeleteRole([FromRoute] string RoleId)
        {
            return NewResult(await _mediator.Send(new DeleteRoleModel(RoleId)));
        }

        [HttpGet(Router.Authorization.GetRoleById)]
        public async Task<IActionResult> GetRoleById([FromRoute] string RoleId)
        {
            return NewResult(await _mediator.Send(new GetRoleByIdModel(RoleId)));
        }

        [HttpGet(Router.Authorization.GetListOfRole)]
        public async Task<IActionResult> GetListOfRoles()
        {
            return NewResult(await _mediator.Send(new GetListOfRolesModel()));
        }



        [HttpGet(Router.Authorization.GetManageUserRole)]
        public async Task<IActionResult> GetManageUserRole([FromRoute] string UserId)
        {
            return NewResult(await _mediator.Send(new ManageUserRolesModel(UserId)));
        }

        [HttpGet(Router.Authorization.UpdateUserRole)]
        public async Task<IActionResult> UpdateUserRole([FromBody]UpdateUserRoleModel model)
        {
            return NewResult(await _mediator.Send(model));
        }

    }
}
