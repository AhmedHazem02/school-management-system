using FluentValidation;
using SchoolProject.Core.Features.Subjects.Commands.Models;
using SchoolProject.Core.Features.User.Command.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Subjects.Commands.Validations
{
    public class AddSubjectValidation : AbstractValidator<AddSubjectCommandModel>
    {
        public AddSubjectValidation()
        {
            ApplicationValidationRule();
            ApplyCustomerValidationRule();
        }

        public void ApplicationValidationRule()
        {
            RuleFor(x => x.SubjectName).NotEmpty().WithMessage("The SubjectName Can Not Be Empty")
                              .NotNull().WithMessage("The SubjectName Can Not Be Null")
                              .MaximumLength(200).WithMessage("Max Lenght Is 200 ");


            RuleFor(x => x.Period).NotEmpty().WithMessage("{PropertyName} The Period Can Not Be Empty")
                              .NotNull().WithMessage("{PropertyName} The Period Can Not Be Null");

        }
        public void ApplyCustomerValidationRule()
        {

        }
    }
}
