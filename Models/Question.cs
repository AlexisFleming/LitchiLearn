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
        public string QuestionName { get; set; }
        [DataType(DataType.Time)]       
        public DateTime StartDateTime { get; set; }
        [DataType(DataType.Time)]
        public DateTime EndDateTime { get; set; }


    }
}
