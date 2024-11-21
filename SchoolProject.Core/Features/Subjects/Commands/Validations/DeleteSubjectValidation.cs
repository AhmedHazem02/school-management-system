using FluentValidation;
using SchoolProject.Core.Features.Subjects.Commands.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Subjects.Commands.Validations
{
    public class DeleteSubjectValidation : AbstractValidator<DeleteSubjectModel>
    {
        public DeleteSubjectValidation()
        {
            ApplicationValidationRule();
            ApplyCustomerValidationRule();
        }

        public void ApplicationValidationRule()
        {

            RuleFor(x => x.Id).NotEmpty().WithMessage("{PropertyName} The ID Can Not Be Empty")
                              .NotNull().WithMessage("{PropertyName} The Id Can Not Be Null");

        }
        public void ApplyCustomerValidationRule()
        {

        }
    }
}
