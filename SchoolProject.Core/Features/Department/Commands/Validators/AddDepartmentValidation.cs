using FluentValidation;
using SchoolProject.Core.Features.Department.Commands.Models;
using SchoolProject.infransturture.Repository.Abstruct;
using SchoolProject.service.Abstracts;
using SchoolProject.service.Impelemetions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Department.Commands.Validators
{
    public class AddDepartmentValidation : AbstractValidator<AddDepartmentModel>
    {
        private readonly IDepartmentService _departmentService;

        public AddDepartmentValidation(IDepartmentService departmentService)
        {

            ApplicationValidationRule();
            ApplyCustomerValidationRule();
            _departmentService = departmentService;
        }

        public void ApplicationValidationRule()
        {
            
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
