using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Department.Query.DTOs
{
    public class DepartmentDto
    {
        public int id { get; set; }
        public string DName { get; set; }
        public string ManagerName { get; set; }
        public List<StudentResponse>?StudentList { get; set; }
        public List<SubjectResponse>?SubjectList { get; set; }
        public List<InstructorResponse>?InstructorList { get; set; }
    }
        public class StudentResponse
        {
           public int id { get; set; }
            public string name { get; set; }
        }

        public class SubjectResponse
        {
            public int id { get; set; }
            public string SubjectName { get; set; }
        }

        public class InstructorResponse
        {
            public int id { get; set; }
            public string  Name { get; set; }
        }
}
