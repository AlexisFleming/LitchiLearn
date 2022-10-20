using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Final_LitchiLearn.Models
{

    public class TimeTable
    {
        [Key]
        [Display(Name ="TimetableID")]
        public int Id { get; set; }
        [ForeignKey("Subject")]
        public string SubjectID { get; set; }

        public string SubjectName { get; set; }
        
        public string Day { get; set; }
        
        public string Time { get; set; }

        public string Venue { get; set; }
    }

}
