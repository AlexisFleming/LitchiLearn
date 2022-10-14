using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Final_LitchiLearn.Models
{
    public class Question
    {
        [Key]
        public int QuestionID { get; set; }
        public string QuesDesc { get; set; }
        public string Answer { get; set; }
        public string Option1 { get; set; }
        public string Option2 { get; set; }
        public string Option3 { get; set; }
        public string Option4 { get; set; }



    }
}
