using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Final_LitchiLearn.Models
{
    public class Result
    {
        [Key]
        
        public int ResultID { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        public string Username { get; set; }

        [ForeignKey("Question")]
        [Required]
        public int QuestionID { get; set; }

        public string ques { get; set; }
        public string UserAnswer { get; set; }
    }
}
