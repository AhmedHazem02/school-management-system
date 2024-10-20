using SchoolProject.Data.Entites.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Data.Entites
{
    public class Instructor:BaseEntity
    {
        public Instructor()
        {
            Instructors=new HashSet<Instructor>();
            Instructor_Subjects=new HashSet<Instructor_Subject>();
        }
        public string Name { get; set; }
        public string Address { get; set; }
        public string? Position { get; set; }

        public int? SuperVisorId {  get; set; }

        public decimal Salary {  get; set; }
        
        public int DepartmentId {  get; set; }
        [ForeignKey("DepartmentId")]
        [InverseProperty("Instructors")]
        public Department? Department { get; set; }

        [InverseProperty("Instructor")]
        public Department? Department_Manager {  get; set; }



        [ForeignKey("SuperVisorId")]
        [InverseProperty("Instructors")]
        public Instructor? SuperVisor { get; set; }
        [InverseProperty("SuperVisor")]
        public virtual ICollection<Instructor> Instructors { get; set; }


        [InverseProperty("Instructor")]
        public virtual ICollection<Instructor_Subject> Instructor_Subjects { get; set; }


    }
}
