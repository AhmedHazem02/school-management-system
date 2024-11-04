
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Authentication.Commands.Models;
using SchoolProject.Data.Entites.Identity;
using SchoolProject.service.Abstracts;

namespace SchoolProject.Core.Features.Authentication.Commands.Handlers
{
    public class AuthenticationCommandHandler : ResponseHandler,
                                          IRequestHandler<SignInCommandModel, Response<string>>
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
        public async Task<Response<string>> Handle(SignInCommandModel request, CancellationToken cancellationToken)
        {
            // If User Exist
            var IfUserExist = await _userManager.FindByNameAsync(request.UserName);
            if (IfUserExist == null) return BadRequest<string>("The User Is Not Found");

            var ResSignIn=   _signInManager.CheckPasswordSignInAsync(IfUserExist, request.Password,false);
            if (!ResSignIn.IsCompletedSuccessfully) return BadRequest<string>("Your Password Is Not Correct");

            // Generate Token
            var AccessToken =  await _authenticationServices.GetJWTToken(IfUserExist);
            return Success(AccessToken);
        }
    }
}
