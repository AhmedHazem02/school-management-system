using MediatR;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Email.Commands.Models;
using SchoolProject.service.Abstracts;


namespace SchoolProject.Core.Features.Email.Commands.Handler
{
    public class EmailCommandHandler : ResponseHandler,
                                          IRequestHandler<SendEmailModel, Response<string>>
    {
        private readonly IEmailServices _emailServices;

        public EmailCommandHandler(IEmailServices emailServices)
        {
             _emailServices = emailServices;
        }
        public async Task<Response<string>> Handle(SendEmailModel request, CancellationToken cancellationToken)
        {
            var res = await _emailServices.SendEmailAsync(request.Email, request.Message);
            if(res== "Success")return Success<string>("");
            return BadRequest<string>(res);
        }
    }
}
