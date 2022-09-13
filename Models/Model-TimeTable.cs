using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_LitchiLearn.Models
{

    public class TimeTable
    {
        [Key]
        public string SubjectID { get; set; }

        public string Subject { get; set; }
        
        public string Day { get; set; }
        
        public string Time { get; set; }

        public string Venue { get; set; }
    }

}
