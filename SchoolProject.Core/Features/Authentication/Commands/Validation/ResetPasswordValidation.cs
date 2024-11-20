using FluentValidation;
using SchoolProject.Core.Features.Authentication.Commands.Models;
using SchoolProject.Core.Features.Authentication.Queries.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Authentication.Commands.Validation
{
    public class ResetPasswordValidation : AbstractValidator<ResetPasswordModel>
    {
        public ResetPasswordValidation()
        {

            ApplicationValidationRule();
            ApplyCustomerValidationRule();
        }

        public void ApplicationValidationRule()
        {
            RuleFor(x => x.Password).NotEmpty().WithMessage("The Password Can Not Be Empty")
                              .NotNull().WithMessage("The Password Can Not Be Null");

            RuleFor(x => x.ConfirmePassword).NotEmpty().WithMessage("{PropertyName} The ConfirmPassword Can Not Be Empty")
                  .NotNull().WithMessage("{PropertyName} The ConfirmPassword Can Not Be Null")
                  .Equal(x => x.Password);

            RuleFor(x => x.Email).NotEmpty().WithMessage("{PropertyName} The Email Can Not Be Empty")
                 .NotNull().WithMessage("{PropertyName} The Email Can Not Be Null")
                 .EmailAddress();


        }
        public void ApplyCustomerValidationRule()
        {

        }

    }
}
