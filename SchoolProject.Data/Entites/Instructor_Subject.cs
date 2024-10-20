using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Data.Entites
{
    public class Instructor_Subject
    {
        [Key]
        public int InstId { get; set; }
        [Key] 
        public int SubId {  get; set; }

        [ForeignKey("InstId")]
        [InverseProperty("Instructor_Subjects")]
        public Instructor? Instructor { get; set; }


        [ForeignKey("SubId")]
        [InverseProperty("Instructor_subjects")]
        public Subject? Subject { get; set; }
    }
}
