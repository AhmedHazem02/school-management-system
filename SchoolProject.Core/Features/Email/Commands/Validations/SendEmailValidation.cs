using FluentValidation;
using SchoolProject.Core.Features.Email.Commands.Models;
using SchoolProject.service.Abstracts;

namespace SchoolProject.Core.Features.Email.Commands.Validations
{
    public class SendEmailValidation:AbstractValidator<SendEmailModel>
    {
    
        public SendEmailValidation()
        {
            
            ApplicationValidationRule();
            ApplyCustomerValidationRule();
        }

        public void ApplicationValidationRule()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("The Email Can Not Be Empty")
                              .NotNull().WithMessage("The Email Can Not Be Null");


            RuleFor(x => x.Message).NotEmpty().WithMessage("{PropertyName} The Message Can Not Be Empty")
                              .NotNull().WithMessage("{PropertyName} The Message Can Not Be Null");
        }
        public void ApplyCustomerValidationRule()
        { 
         
        }
    }
}
