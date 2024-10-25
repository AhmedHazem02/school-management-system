using AutoMapper;
using Azure.Core;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Core.Features.User.Command.Models;
using SchoolProject.Data.Entites.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.User.Command.Handlers
{
    public class UserCommandHandler : ResponseHandler,
                                          IRequestHandler<AddUser, Response<string>>
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
    }
}

