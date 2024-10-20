using FluentValidation;
using Microsoft.Identity.Client;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.service.Abstracts;

namespace SchoolProject.Core.Features.Students.Commands.Validators
{
    public class AddStudentValidator:AbstractValidator<AddStudentCommand>
    {
        private readonly IStudentService _studentService;

        public AddStudentValidator(IStudentService studentService)
        {
            _studentService = studentService;
            ApplicationValidationRule();
            ApplyCustomerValidationRule();
        }
 
        public void ApplicationValidationRule()
        {
            RuleFor(x => x.name).NotEmpty().WithMessage("The Name Can Not Be Empty")
                              .NotNull().WithMessage("The Name Can Not Be Null")
                              .MaximumLength(50).WithMessage("Max Lenght Is 50 ");


            RuleFor(x=>x.Address).NotEmpty().WithMessage("{PropertyName} The Address Can Not Be Empty")
                              .NotNull().WithMessage("{PropertyName} The Address Can Not Be Null")
                              .MaximumLength(100).WithMessage("{PropertyName} Max Lenght Is 100 ");
        }
        public void ApplyCustomerValidationRule()
        { 
            RuleFor(X => X.name).MustAsync(async (key, CancellationToken) => !await _studentService.IsNameExist(key))
                               .WithMessage("The Name Is Exist");
        }
    }
}
