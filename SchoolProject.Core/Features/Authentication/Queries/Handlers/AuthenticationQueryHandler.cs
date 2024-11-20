using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Authentication.Commands.Models;
using SchoolProject.Core.Features.Authentication.Queries.Models;
using SchoolProject.Data.Helpers;
using SchoolProject.service.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Authentication.Queries.Handlers
{
    public class AuthenticationQueryHandler : ResponseHandler,
                                          IRequestHandler<ConfirmEmailQueryModel, Response<string>>
    {
        private readonly IAuthenticationServices _authenticationServices;

        public AuthenticationQueryHandler(IAuthenticationServices authenticationServices)
        {
              _authenticationServices = authenticationServices;
        }
        public async Task<Response<string>> Handle(ConfirmEmailQueryModel request, CancellationToken cancellationToken)
        {
             var Res= await _authenticationServices.ConfirmeEmail(request.UserId,request.Code);
            if (Res == "Invalid") return BadRequest<string>(Res);
            else if (Res == "Success") return Success("");
            else return BadRequest<string>();

        }
    }
}
