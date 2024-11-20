using AutoMapper;
using Azure.Core;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Core.Features.User.Command.Models;
using SchoolProject.Core.Features.User.Queries.DTOs;
using SchoolProject.Data.Entites.Identity;
using SchoolProject.service.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.User.Command.Handlers
{
    public class UserCommandHandler : ResponseHandler,
                                          IRequestHandler<AddUser, Response<string>>,
                                          IRequestHandler<EditUserModel, Response<string>>,
                                          IRequestHandler<DeleteUserModel, Response<string>>,
                                          IRequestHandler<ChangePasswordModel, Response<string>>
    {
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        private readonly IUserAppServices _userAppServices;

        public UserCommandHandler(IMapper mapper
                                 ,UserManager<AppUser> userManager
                                 ,IUserAppServices userAppServices)
                                 
        {
            _mapper = mapper;
            _userManager = userManager;
            _userAppServices = userAppServices;
        }

        public async Task<Response<string>> Handle(AddUser request, CancellationToken cancellationToken)
        {
            var UserMapping = _mapper.Map<AppUser>(request);
            var CreateRes = await _userAppServices.CreateUser(UserMapping, request.Password);
            if (CreateRes == "This Email Is Used") return BadRequest<string>(CreateRes);
            else if (CreateRes == "This UserName Is Used") BadRequest<string>(CreateRes);
            else if (CreateRes == "Success") return Success<string>("");
            return BadRequest<string>(CreateRes); 
        }

        public async Task<Response<string>> Handle(EditUserModel request, CancellationToken cancellationToken)
        {
            // If Exist
            var OldUser =await _userManager.FindByNameAsync(request.UserName);
            if (OldUser == null) return NotFound<string>("The User Not Found");

            // Mapping
            var UserMapping = _mapper.Map(request,OldUser);
            // Edit
            var EditUser = await _userManager.UpdateAsync(UserMapping);
            if (!EditUser.Succeeded) return BadRequest<string>("Can Not Edit In This User");
            return Success("");
        }

        public async Task<Response<string>> Handle(DeleteUserModel request, CancellationToken cancellationToken)
        {
            // If Exist
            var User = await _userManager.FindByNameAsync(request.UserName);
            if (User == null) return NotFound<string>("The User Not Found");

            var res=await _userManager.DeleteAsync(User);

            if (res.Succeeded) return Success<string>($"Delete UserName : [{request.UserName}] Is Done");
            return BadRequest<string>("Fail");
        }

        public async Task<Response<string>> Handle(ChangePasswordModel request, CancellationToken cancellationToken)
        {
            var User = await _userManager.FindByIdAsync(request.Id);
            if (User == null) return NotFound<string>("The User Not Found");

            var res=await _userManager.ChangePasswordAsync(User,request.OldPassword,request.NewPassword);
            if (res.Succeeded) return Success<string>($"Change Password Is Done");
            return BadRequest<string>("Fail");
        }
    }
}

