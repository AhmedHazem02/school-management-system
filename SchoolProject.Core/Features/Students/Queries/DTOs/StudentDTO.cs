using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Students.Queries.DTOs
{
    public class StudentDTO
    {
        public int Id { get; set; }
        public string? name { get; set; }
        
        public string? Address { get; set; }

        public string? Phone { get; set; }

        public string?DepartmentName { get; set; }
    }
}
