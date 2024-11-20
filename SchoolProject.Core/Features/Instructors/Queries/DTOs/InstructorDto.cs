using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Instructors.Queries.DTOs
{
    public class InstructorDto
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Position { get; set; }

        public int SuperVisorId { get; set; }

        public decimal Salary { get; set; }
        public int DepartmentId { get; set; }
    }
}
