using FluentValidation;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.service.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Students.Commands.Validators
{
    public class EditStudentValidator:AbstractValidator<EditStudentCommand>
    {
        private readonly IStudentService _studentService;

        public EditStudentValidator(IStudentService studentService)
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


            RuleFor(x => x.Address).NotEmpty().WithMessage("{PropertyName} The Address Can Not Be Empty")
                              .NotNull().WithMessage("{PropertyName} The Address Can Not Be Null")
                              .MaximumLength(100).WithMessage("{PropertyName} Max Lenght Is 100 ");
        }
        public void ApplyCustomerValidationRule()
        {
            RuleFor(X => X.name).MustAsync(async (model,key, CancellationToken) => !await _studentService.IsNameExistExcludeSelf(key,model.id))
                               .WithMessage("The Name Is Exist");
        }
    }
}
