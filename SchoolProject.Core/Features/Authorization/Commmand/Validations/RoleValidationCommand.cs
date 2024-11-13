using FluentValidation;
using SchoolProject.Core.Features.Authorization.Commmand.Models;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.service.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Authorization.Commmand.Validations
{
    public class RoleValidationCommand : AbstractValidator<AddRoleModelCommand>
    {
        private readonly IAuthorizationService _authorizationService;

        public RoleValidationCommand (IAuthorizationService authorizationService)
        {
            
            ApplicationValidationRule();
            ApplyCustomerValidationRule();
            _authorizationService = authorizationService;
        }

        public void ApplicationValidationRule()
        {
            RuleFor(x => x.RoleName).NotEmpty().WithMessage("The Name Can Not Be Empty")
                              .NotNull().WithMessage("The Name Can Not Be Null")
                              .MaximumLength(50).WithMessage("Max Lenght Is 50 ");


           
        }
        public void ApplyCustomerValidationRule()
        {
            RuleFor(X => X.RoleName).MustAsync(async (key, CancellationToken) => !await _authorizationService.IsRoleExist(key))
                               .WithMessage("The Name Is Exist");
             
        }
    }
}

