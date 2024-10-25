using FluentValidation;
using Microsoft.Identity.Client;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.service.Abstracts;

namespace SchoolProject.Core.Features.Students.Commands.Validators
{
    public class AddStudentValidator:AbstractValidator<AddStudentCommand>
    {
        private readonly IStudentService _studentService;
        private readonly IDepartmentService _departmentService;

        public AddStudentValidator(IStudentService studentService,IDepartmentService departmentService)
        {
            _studentService = studentService;
            _departmentService = departmentService;
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

            RuleFor(x => x.DepartmentId).NotEmpty().WithMessage("{PropertyName} The Department ID Can Not Be Empty")
                             .NotNull().WithMessage("{PropertyName} The Department ID Can Not Be Null");
                             


        }
        public void ApplyCustomerValidationRule()
        { 
            RuleFor(X => X.name).MustAsync(async (key, CancellationToken) => !await _studentService.IsNameExist(key))
                               .WithMessage("The Name Is Exist");
            RuleFor(X => X.DepartmentId).MustAsync(async (key, CancellationToken) => await _departmentService.IsDepartmentExist(key))
                              .WithMessage("The Department Is Not Exist");
        }
    }
}
