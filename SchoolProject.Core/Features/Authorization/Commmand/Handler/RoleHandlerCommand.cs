using MediatR;
using Microsoft.AspNetCore.Identity;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Authorization.Commmand.Models;
using SchoolProject.service.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Authorization.Commmand.Handler
{
    public class RoleHandlerCommand : ResponseHandler,
                                          IRequestHandler<AddRoleModelCommand, Response<string>>,
                                          IRequestHandler<EditRoleModel, Response<string>>,
                                          IRequestHandler<DeleteRoleModel, Response<string>>,
                                          IRequestHandler<UpdateUserRoleModel, Response<string>>

    {
        private readonly IAuthorizationService _authorizationService;

        public RoleHandlerCommand(IAuthorizationService authorizationService)
        {
             _authorizationService = authorizationService;
        }
        public async  Task<Response<string>> Handle(AddRoleModelCommand request, CancellationToken cancellationToken)
        {
            var Res =await _authorizationService.AddRoleAsync(request.RoleName);
            if(Res== "Success") return Success("");
            return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(EditRoleModel request, CancellationToken cancellationToken)
        {
            var res = await _authorizationService.EditRoleAsync(request);
            if (res == "NotFound") return NotFound<string>();
            if (res == "Succeed") return Success<string>("Update Is Done");
            return BadRequest<string>(res);
        }

        public async Task<Response<string>> Handle(DeleteRoleModel request, CancellationToken cancellationToken)
        {
            var res = await _authorizationService.DeleteRoleAsync(request.RoleId);
            if (res == "NotFound") return NotFound<string>();
            else if (res == "Succeed") return Success<string>("Delete Is Done");
            else if (res == "Used") return UnprocessableEntity<string>("Is Used");
            return BadRequest<string>(res);
        }

        public async Task<Response<string>> Handle(UpdateUserRoleModel request, CancellationToken cancellationToken)
        {
            var Res = await _authorizationService.UpdateUserRoles(request);
            if(Res== "UserNotFound")return NotFound<string>(Res);
            else if(Res== "FaildToRemoveRoles")return BadRequest<string>(Res);
            else if(Res== "FaildToSuccess")return BadRequest<string>(Res);
            else if(Res== "Faild")return BadRequest<string>(Res);
            else return Success(Res);
        }
    }
}
