using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_LitchiLearn.Models
{
    public class ReportStudent
    {
        [Key]
        public int StudentID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Grade { get; set; }

        public int Year { get; set; }

        public string Teacher { get; set; }

        public int Subject { get; set; }

        public string Mark { get; set; }

    }
}