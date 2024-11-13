using FluentValidation;
using SchoolProject.Core.Features.Authorization.Commmand.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Authorization.Commmand.Validations
{
    public class DeleteRoleValidation :AbstractValidator<DeleteRoleModel>
    {
   

        public DeleteRoleValidation()
    {

        ApplicationValidationRule();
        ApplyCustomerValidationRule();

    }

    public void ApplicationValidationRule()
    {

        RuleFor(x => x.RoleId).NotEmpty().WithMessage("The Id Can Not Be Empty")
                         .NotNull().WithMessage("The Id Can Not Be Null");


    }
    public void ApplyCustomerValidationRule()
    {
    }
}
}
