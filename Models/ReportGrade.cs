using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_LitchiLearn.Models
{
    public class ReportGrade
    {
        [Key]
        public int GradeID { get; set; }

        public string GradeName { get; set; }

        public int Year { get; set; }

        public string Month { get; set; }

        public int GradeAverage { get; set; }





    }

}