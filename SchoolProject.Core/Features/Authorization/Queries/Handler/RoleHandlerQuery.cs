using AutoMapper;
using AutoMapper.Configuration.Annotations;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Authorization.Commmand.Models;
using SchoolProject.Core.Features.Authorization.DTOs;
using SchoolProject.Core.Features.Authorization.Queries.Models;
using SchoolProject.Data.DTOs;
using SchoolProject.Data.Entites.Identity;
using SchoolProject.service.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Authorization.Queries.Handler
{
    public class RoleHandlerQuery : ResponseHandler,
                                          IRequestHandler<GetRoleByIdModel, Response<GetRoleDTO>>,
                                          IRequestHandler<GetListOfRolesModel, Response<List<GetRoleDTO>>>,
                                           IRequestHandler<ManageUserRolesModel, Response<ManageUserRolesDTO>>


    {
        private readonly IAuthorizationService _authorizationService;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;

        public RoleHandlerQuery(IAuthorizationService authorizationService,IMapper mapper,
                                UserManager<AppUser>userManager)
        {
            _authorizationService = authorizationService;
            _mapper = mapper;
            _userManager = userManager;
        }
        public async Task<Response<GetRoleDTO>> Handle(GetRoleByIdModel request, CancellationToken cancellationToken)
        {
            var res=await _authorizationService.GetRoleById(request.RoleId);
            if (res==null)return NotFound<GetRoleDTO>("");
            var RoleMapping =  _mapper.Map<GetRoleDTO>(res);
            return Success(RoleMapping);
        }

        public async Task<Response<List<GetRoleDTO>>> Handle(GetListOfRolesModel request, CancellationToken cancellationToken)
        {
            var ListOfRole = await _authorizationService.GetListOfRoles();
            var ResMapping= _mapper.Map<List<GetRoleDTO>>(ListOfRole);
            return Success(ResMapping);
        }

        public async Task<Response<ManageUserRolesDTO>> Handle(ManageUserRolesModel request, CancellationToken cancellationToken)
        {
            var res = await _userManager.FindByIdAsync(request.UserId);
            if (res == null) return NotFound<ManageUserRolesDTO>();
            var Res = await _authorizationService.GetManageUserRole(res);
            return Success(Res);
        }

    }
}
