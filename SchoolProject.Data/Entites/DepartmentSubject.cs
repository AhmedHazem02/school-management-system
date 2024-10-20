using SchoolProject.Data.Entites.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Data.Entites
{
    public class DepartmentSubject 
    {
        public int SubjectId { get; set; }
        public int DepartmentId { get; set;}

        [ForeignKey("DepartmentId")]
        [InverseProperty("DepartmentSubjects")]
        public virtual Department? Department { get; set; }

        [ForeignKey("SubjectId")]
        [InverseProperty("DepartmentSubjects")]
        public virtual Subject? Subject { get; set; }
    }
}
