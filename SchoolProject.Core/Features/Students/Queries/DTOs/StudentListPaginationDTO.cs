using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Students.Queries.DTOs
{
    public class StudentListPaginationDTO
    {
        public int Id { get; set; }
        public string? name { get; set; }
        public string? Address { get; set; }
        public string? DepartmentName { get; set; }

        public StudentListPaginationDTO(int id,string? Name,string? address,string ?Departmentname)
        {
            Id = id;
            Name = name;
            Address = address;
            DepartmentName = Departmentname;
            
        }
    }
}
