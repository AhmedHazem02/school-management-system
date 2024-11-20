using MediatR;
using SchoolProject.Core.Bases;
 

namespace SchoolProject.Core.Features.Authentication.Commands.Models
{
    public class ConfirmeResetPasswordModel:IRequest<Response<string>>
    {
        public string Email {  get; set; }
    }
}
