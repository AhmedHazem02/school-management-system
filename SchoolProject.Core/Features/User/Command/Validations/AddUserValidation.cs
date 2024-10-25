using FluentValidation;
using SchoolProject.Core.Features.User.Command.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.User.Command.Validations
{
    public class AddUserValidation:AbstractValidator<AddUser>
    {
        public AddUserValidation()
        {
          ApplicationValidationRule();
          ApplyCustomerValidationRule();
        }

      public void ApplicationValidationRule()
      {
        RuleFor(x => x.DisplayName).NotEmpty().WithMessage("The Name Can Not Be Empty")
                          .NotNull().WithMessage("The Name Can Not Be Null")
                          .MaximumLength(200).WithMessage("Max Lenght Is 200 ");


            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("{PropertyName} The PhoneNumber Can Not Be Empty")
                              .NotNull().WithMessage("{PropertyName} The PhoneNumber Can Not Be Null");
                          
        RuleFor(x => x.UserName).NotEmpty().WithMessage("{PropertyName} The UserName Can Not Be Empty")
                         .NotNull().WithMessage("{PropertyName} The UserName Can Not Be Null");

        RuleFor(x => x.Password).NotEmpty().WithMessage("{PropertyName} The Password Can Not Be Empty")
                        .NotNull().WithMessage("{PropertyName} The Password Can Not Be Null");

         RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("{PropertyName} The ConfirmPassword Can Not Be Empty")
                 .NotNull().WithMessage("{PropertyName} The ConfirmPassword Can Not Be Null")
                 .Equal(x=>x.Password);

            RuleFor(x => x.Email).NotEmpty().WithMessage("{PropertyName} The Email Can Not Be Empty")
                 .NotNull().WithMessage("{PropertyName} The Email Can Not Be Null")
                 .EmailAddress();





      }
        public void ApplyCustomerValidationRule()
        { 

        }
    }
}
