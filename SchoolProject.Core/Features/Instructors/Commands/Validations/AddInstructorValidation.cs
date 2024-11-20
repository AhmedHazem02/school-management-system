using FluentValidation;
using SchoolProject.Core.Features.Instructors.Commands.Models;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.service.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Instructors.Commands.Validations
{
    public class AddInstructorValidation : AbstractValidator<AddInstructorModel>
    {
        private readonly IDepartmentService _departmentService;

        public AddInstructorValidation(IDepartmentService departmentService )
        {
            
            ApplicationValidationRule();
            ApplyCustomerValidationRule();
            _departmentService = departmentService;
        }

        public void ApplicationValidationRule()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("The Name Can Not Be Empty")
                              .NotNull().WithMessage("The Name Can Not Be Null")
                              .MaximumLength(50).WithMessage("Max Lenght Is 50 ");

            RuleFor(x => x.SuperVisorId).NotEmpty().WithMessage("The SuperVisorId Can Not Be Empty")
                              .NotNull().WithMessage("The SuperVisorId Can Not Be Null");

            RuleFor(x => x.DepartmentId).NotEmpty().WithMessage("The DepartmentId Can Not Be Empty")
                             .NotNull().WithMessage("The DepartmentId Can Not Be Null");



            RuleFor(x => x.Address).NotEmpty().WithMessage("{PropertyName} The Address Can Not Be Empty")
                              .NotNull().WithMessage("{PropertyName} The Address Can Not Be Null")
                              .MaximumLength(100).WithMessage("{PropertyName} Max Lenght Is 100 ");
            
            RuleFor(x => x.Salary).NotEmpty().WithMessage("{PropertyName} The Salary Can Not Be Empty")
                             .NotNull().WithMessage("{PropertyName} The Salary Can Not Be Null");
        }
        public void ApplyCustomerValidationRule()
        {
            RuleFor(X => X.DepartmentId).MustAsync(async (key, CancellationToken) => await _departmentService.IsDepartmentExist(key))
                             .WithMessage("The Department Nor Exist");
        }
    }
}

