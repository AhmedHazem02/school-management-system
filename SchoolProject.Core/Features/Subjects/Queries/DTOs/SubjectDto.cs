using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Subjects.Queries.DTOs
{
    public class SubjectDto
    {
        public int Id { get; set; }
        public string SubjectName { get; set; }
       public DateTime Period { get; set; }  
    }
}
