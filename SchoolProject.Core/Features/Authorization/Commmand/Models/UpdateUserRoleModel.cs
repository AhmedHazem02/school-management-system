﻿using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Data.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Authorization.Commmand.Models
{
    public class UpdateUserRoleModel: UpdateRoleManagerDto,IRequest<Response<string>>
    {
        
        
    }
}
