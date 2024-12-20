﻿
using MediatR;
using SchoolProject.Core.Bases;

namespace SchoolProject.Core.Features.Authentication.Queries.Models
{
    public class ConfirmeResetPasswordQueryModel:IRequest<Response<string>>
    {
        public string Code {  get; set; }
        public string Email { get; set; }
    }
}
