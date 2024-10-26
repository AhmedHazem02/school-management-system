using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.User.Queries.DTOs;
using SchoolProject.Core.Features.User.Queries.Models;
using SchoolProject.Core.Pagination;
using SchoolProject.Data.Entites.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.User.Queries.Handlers
{
    public class UserQueryHandler : ResponseHandler,
                                 IRequestHandler<GetUsersListPagination, PaginatedResult<UsersListPaginationDTO>>,
                                  IRequestHandler<GetUserByUserName,Response<UserDTO>>

    {

        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;

        public UserQueryHandler(IMapper mapper, UserManager<AppUser> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }


        public async  Task<PaginatedResult<UsersListPaginationDTO>> Handle(GetUsersListPagination request, CancellationToken cancellationToken)
        {
            var Users=_userManager.Users.AsQueryable();
            var UsersMapping= await _mapper.ProjectTo<UsersListPaginationDTO>(Users)
                                    .ToPaginatedListAsync(request.PageIndex,request.PageSize);
            return UsersMapping;

        }

        public async Task<Response<UserDTO>> Handle(GetUserByUserName request, CancellationToken cancellationToken)
        {
            var User =  await _userManager.Users.FirstOrDefaultAsync(x => x.UserName.Equals(request.UserName));
            if (User is null) return NotFound<UserDTO>();
            var UserMapping =  _mapper.Map<UserDTO>(User);
            return Success(UserMapping);
        }
    }
}
