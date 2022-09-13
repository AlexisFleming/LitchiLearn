﻿using Microsoft.AspNetCore.Identity;
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
        public int UserID { get; set; }
        
        public int Grade { get; set; }
        
        public int SubjectID { get; set; }

       public string TimeTableData { get; set; }
    }

}
