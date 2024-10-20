using SchoolProject.Data.Entites.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Data.Entites
{
    public class StudentSubject  
    {
        public int StudentId {  get; set; }
        public int SubjectId {  get; set; }
        public decimal?Grade { get; set; }  

        [ForeignKey("StudentId")]
        [InverseProperty("Student_Subjects")]
        public virtual Student? student { get; set; }
        [ForeignKey("SubjectId")]
        [InverseProperty("StudentSubjects")]

        public virtual Subject? Subject { get; set; }
    }
}
