using FluentValidation;
using SchoolProject.Core.Features.Authentication.Commands.Models;
using SchoolProject.Core.Features.Authentication.Queries.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Authentication.Queries.Validations
{
    public class ConfirmeResetPasswordValidationQuery : AbstractValidator<ConfirmeResetPasswordQueryModel>
    {
        public ConfirmeResetPasswordValidationQuery()
        {

            ApplicationValidationRule();
            ApplyCustomerValidationRule();
        }

        public void ApplicationValidationRule()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("The Email Can Not Be Empty")
                              .NotNull().WithMessage("The Email Can Not Be Null");

            RuleFor(x => x.Code).NotEmpty().WithMessage("The Code Can Not Be Empty")
                              .NotNull().WithMessage("The Code Can Not Be Null");

        }
        public void ApplyCustomerValidationRule()
        {

        }

    }
}

