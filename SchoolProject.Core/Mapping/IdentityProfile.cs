using AutoMapper;
using SchoolProject.Core.Features.User.Command.Models;
using SchoolProject.Core.Features.User.Queries.DTOs;
using SchoolProject.Data.Entites.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Mapping
{
    public class IdentityProfile:Profile
    {
        public IdentityProfile() { 
           CreateMap<AddUser,AppUser>();
            CreateMap<AppUser, UsersListPaginationDTO>();
            CreateMap<AppUser,UserDTO>();
        }
    }
}
