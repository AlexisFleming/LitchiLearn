using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Final_LitchiLearn.Models
{
    public class Quiz
    {
        [Key]
        public int QuizID { get; set; }
        [Required]
        public string QuizName { get; set; }
        [Required]
        public int TotalMarks { get; set; }
        [ForeignKey("Topic")]
        public int TopicID { get; set; }
        
        public Topics Topics { get; set; }
        public ICollection<Question> Questions { get; set; }



    }
}
