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
        public int Grade { get; set; }
        [Key ]
       public string TimeTableData { get; set; }
    }
}
