using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;


namespace Final_LitchiLearn.Models
{
    public class Enrol
    {
        [Key]
        public int EnrolID { get; set; }
        [ForeignKey("User")]
        public int StudentID { get; set; }
        [ForeignKey("Subject")]
        public string SubjectID { get; set; }
        
         }
   

}
