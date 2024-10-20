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
    public class Subject :BaseEntity
    {
        public Subject() { 
           StudentSubjects=new HashSet<StudentSubject>();
            DepartmentSubjects=new HashSet<DepartmentSubject>();
            Instructor_subjects = new HashSet<Instructor_Subject>();
        }
        [StringLength(50)]
        public string SubjectName {  get; set; }
        public DateTime Period { get; set; }

        [InverseProperty("Subject")]

        public virtual ICollection<DepartmentSubject> DepartmentSubjects { get; set; }

        [InverseProperty("Subject")]

        public virtual ICollection<StudentSubject> StudentSubjects { get; set; }

        [InverseProperty("Subject")]
        public virtual ICollection<Instructor_Subject>Instructor_subjects  { get; set; }

    }
}
