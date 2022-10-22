using System.ComponentModel.DataAnnotations;

namespace Final_LitchiLearn.Models
{
    public class Subject
    {
        [Key]
        public int SubjectID { get; set; }
        [Required(ErrorMessage ="Please enter the subject name.")]
        public string SubjectName { get; set; } 
    
    }    
}
