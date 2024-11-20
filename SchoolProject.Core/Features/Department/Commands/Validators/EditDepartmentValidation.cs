using FluentValidation;
using SchoolProject.Core.Behaviors;
using SchoolProject.Core.Features.Department.Commands.Models;
using SchoolProject.service.Abstracts;
using SchoolProject.service.Impelemetions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Department.Commands.Validators
{
    public class EditDepartmentValidation:AbstractValidator<EditDepartmentModel>
    {
        private readonly IDepartmentService _departmentService;

        public EditDepartmentValidation(IDepartmentService departmentService)
        {

            ApplicationValidationRule();
            ApplyCustomerValidationRule();
            _departmentService = departmentService;
        }
        public void ApplicationValidationRule()
        {
            RuleFor(x => x.DeptId).NotEmpty().WithMessage("The DeptId Can Not Be Empty")
                              .NotNull().WithMessage("The DeptId Can Not Be Null");
            RuleFor(x => x.Name).NotEmpty().WithMessage("The Name Can Not Be Empty")
                              .NotNull().WithMessage("The Name Can Not Be Null");


        }
        public void ApplyCustomerValidationRule()
        {
            RuleFor(X => X.Name).MustAsync(async (key, CancellationToken) => !await _departmentService.IsNameExist(key))
                              .WithMessage("The Name Is Exist");

        }
    }
}

