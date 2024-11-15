using FluentValidation;
using SchoolProject.Core.Features.Authorization.Commmand.Models;
using SchoolProject.service.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Authorization.Commmand.Validations
{
    public class EditRoleValidation: AbstractValidator<EditRoleModel>
    {
   

        public EditRoleValidation()
        {

            ApplicationValidationRule();
            ApplyCustomerValidationRule();
             
        }

        public void ApplicationValidationRule()
        {

            RuleFor(x => x.Id).NotEmpty().WithMessage("The Id Can Not Be Empty")
                             .NotNull().WithMessage("The Id Can Not Be Null");



            RuleFor(x => x.Name).NotEmpty().WithMessage("The Name Can Not Be Empty")
                              .NotNull().WithMessage("The Name Can Not Be Null");
                              



        }
        public void ApplyCustomerValidationRule()
        {
        }
    }
}
