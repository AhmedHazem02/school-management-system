
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Authentication.Commands.Models;
using SchoolProject.Data.Entites.Identity;
using SchoolProject.Data.Helpers;
using SchoolProject.service.Abstracts;

namespace SchoolProject.Core.Features.Authentication.Commands.Handlers
{
    public class AuthenticationCommandHandler : ResponseHandler,
                                          IRequestHandler<SignInCommandModel, Response<JwtAuthResult>>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IAuthenticationServices _authenticationServices;

        public AuthenticationCommandHandler(
                                             UserManager<AppUser>userManager,
                                             SignInManager<AppUser>signInManager,
                                             IAuthenticationServices authenticationServices)
        {
              _userManager = userManager;
              _signInManager = signInManager;
              _authenticationServices = authenticationServices;
        }
        public async Task<Response<JwtAuthResult>> Handle(SignInCommandModel request, CancellationToken cancellationToken)
        {
            // If User Exist
            var IfUserExist = await _userManager.FindByNameAsync(request.UserName);
            if (IfUserExist == null) return BadRequest<JwtAuthResult>("The User Is Not Found");

            var ResSignIn=   _signInManager.CheckPasswordSignInAsync(IfUserExist, request.Password,false);
            if (!ResSignIn.IsCompletedSuccessfully) return BadRequest<JwtAuthResult>("Your Password Is Not Correct");

            // Generate Token
            var Res =  await _authenticationServices.GetJWTToken(IfUserExist);
            return Success(Res);
        }
    }
}
