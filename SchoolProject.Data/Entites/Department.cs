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
    public class Department :BaseEntity
    {
    
        public Department() { 
           Students = new HashSet<Student>();
           DepartmentSubjects = new HashSet<DepartmentSubject>();
             
        }
        [StringLength(200)]

        public string DName { get; set; }
        public int? Ins_Manager {  get; set; }
        [InverseProperty("Department")]

        public virtual ICollection<DepartmentSubject> DepartmentSubjects { get; set; }
        [InverseProperty("Department")]
        public virtual ICollection<Student>Students  { get; set; }

        [InverseProperty("Department")]
        public virtual ICollection<Instructor> Instructors { get; set; }
        [ForeignKey("Ins_Manager")]
        [InverseProperty("Department_Manager")]
        public virtual Instructor?  Instructor { get; set; }

    }
}
