﻿using FluentValidation;
using SchoolProject.Core.Features.Authentication.Commands.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Authentication.Commands.Validation
{
    public class ConfirmeResetPasswordValidation:AbstractValidator<ConfirmeResetPasswordModel>
    {
        public ConfirmeResetPasswordValidation()
        {

            ApplicationValidationRule();
            ApplyCustomerValidationRule();
        }

        public void ApplicationValidationRule()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("The Email Can Not Be Empty")
                              .NotNull().WithMessage("The Email Can Not Be Null");


           
        }
        public void ApplyCustomerValidationRule()
        {

        }
    
}
}