using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_LitchiLearn.Models
{
    public class Enrol
    {
        [Key]
        public int EnrolID { get; set; }
        
        public int StudentID { get; set; }
        
        public string SubjectID { get; set; }

    }

}
