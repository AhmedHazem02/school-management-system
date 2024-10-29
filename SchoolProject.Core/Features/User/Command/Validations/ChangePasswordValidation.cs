using FluentValidation;
using SchoolProject.Core.Features.User.Command.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.User.Command.Validations
{
    public class ChangePasswordValidation : AbstractValidator<ChangePasswordModel>
    {
        public ChangePasswordValidation()
        {
            ApplicationValidationRule();
            ApplyCustomerValidationRule();
        }

        public void ApplicationValidationRule()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("The Name Can Not Be Empty")
                              .NotNull().WithMessage("The Name Can Not Be Null");
                              

            RuleFor(x => x.NewPassword).NotEmpty().WithMessage("{PropertyName} The Password Can Not Be Empty")
                            .NotNull().WithMessage("{PropertyName} The Password Can Not Be Null");

            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("{PropertyName} The ConfirmPassword Can Not Be Empty")
                    .NotNull().WithMessage("{PropertyName} The ConfirmPassword Can Not Be Null")
                    .Equal(x => x.NewPassword);

        }
        public void ApplyCustomerValidationRule()
        {

        }
    }
}
