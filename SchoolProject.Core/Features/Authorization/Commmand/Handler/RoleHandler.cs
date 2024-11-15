using MediatR;
using Microsoft.AspNetCore.Identity;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Authorization.Commmand.Models;
using SchoolProject.service.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Authorization.Commmand.Handler
{
    public class RoleHandler : ResponseHandler,
                                          IRequestHandler<AddRoleModelCommand, Response<string>>
    {
        private readonly IAuthorizationService _authorizationService;

        public RoleHandler(IAuthorizationService authorizationService)
        {
             _authorizationService = authorizationService;
        }
        public async  Task<Response<string>> Handle(AddRoleModelCommand request, CancellationToken cancellationToken)
        {
            var Res =await _authorizationService.AddRoleAsync(request.RoleName);
            if(Res== "Success") return Success("");
            return BadRequest<string>();
        }
    }
}
