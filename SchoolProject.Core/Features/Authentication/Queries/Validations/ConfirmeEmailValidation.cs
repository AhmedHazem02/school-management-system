using FluentValidation;
using SchoolProject.Core.Features.Authentication.Queries.Models;
using SchoolProject.Core.Features.Email.Commands.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Authentication.Queries.Validations
{
    public class ConfirmeEmailValidation : AbstractValidator<ConfirmEmailQueryModel>
    {

        public ConfirmeEmailValidation()
        {

            ApplicationValidationRule();
            ApplyCustomerValidationRule();
        }

        public void ApplicationValidationRule()
        {
            RuleFor(x => x.UserId).NotEmpty().WithMessage("The UserId Can Not Be Empty")
                              .NotNull().WithMessage("The UserId Can Not Be Null");


            RuleFor(x => x.Code).NotEmpty().WithMessage("{PropertyName} The Code Can Not Be Empty")
                              .NotNull().WithMessage("{PropertyName} The Code Can Not Be Null");
        }
        public void ApplyCustomerValidationRule()
        {

        }
    }
}
