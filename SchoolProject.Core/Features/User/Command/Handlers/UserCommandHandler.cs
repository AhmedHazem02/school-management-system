using AutoMapper;
using Azure.Core;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Core.Features.User.Command.Models;
using SchoolProject.Core.Features.User.Queries.DTOs;
using SchoolProject.Data.Entites.Identity;
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

        public UserCommandHandler(IMapper mapper,UserManager<AppUser> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<Response<string>> Handle(AddUser request, CancellationToken cancellationToken)
        {
            // if Email Exist
            if (await _userManager.FindByEmailAsync(request.Email)!= null)
                return BadRequest<string>("This Email Is Used");
            // if User Name Is Exist
            if (await _userManager.FindByNameAsync(request.UserName)!= null) 
                return BadRequest<string>("This UserName Is Used");
            // Mapping
            var UserMapping = _mapper.Map<AppUser>(request);

            // Create
            var Create=await _userManager.CreateAsync(UserMapping,request.Password);

            if (!Create.Succeeded) return BadRequest<string>(Create.Errors.FirstOrDefault().Description);

            return Created("");

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

