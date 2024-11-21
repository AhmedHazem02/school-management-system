using MediatR;
using SchoolProject.Core.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Subjects.Commands.Models
{
    public class AddSubjectCommandModel:IRequest<Response<string>>
    {
        public string SubjectName { get; set; }
        public DateTime Period { get; set; }
    }
}
