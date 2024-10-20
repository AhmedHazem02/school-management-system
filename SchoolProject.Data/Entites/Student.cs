using SchoolProject.Data.Entites.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Data.Entites
{
    public class Student :BaseEntity
    {
        public Student()
        {
            Student_Subjects=new HashSet<StudentSubject>();
        }

        [StringLength(200)]
        public string name { get; set; }
        public int? age { get; set; }
        [StringLength(200)]
        public string? Address {  get; set; }

        public string? Phone { get; set; }

        public int? DepartmentId {  get; set; }

        
        [ForeignKey("DepartmentId")]
        public virtual Department? Department { get; set; }

        [InverseProperty("student")]

        public virtual ICollection<StudentSubject> Student_Subjects { get; set; }



    }
}
