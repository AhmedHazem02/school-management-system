using AutoMapper;
using Microsoft.AspNetCore.Identity;
using SchoolProject.Core.Features.Authorization.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Mapping
{
     public class AuthorizationProfile:Profile
     {
        public AuthorizationProfile()
        {
            CreateMap<IdentityRole,GetRoleDTO>()
                      .ForMember(dest=>dest.RoleName,opt=>opt.MapFrom(src=>src.Name))
                      .ForMember(dest=>dest.Id,opt=>opt.MapFrom(src=>src.Id));
        }
    }
}
