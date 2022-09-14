using System.ComponentModel.DataAnnotations;

namespace Final_LitchiLearn.Models
{
    public class AdminSubject
    {
        [Key]
        public int SubjectID { get; set; }
        [Required]
        public string SubjectName { get; set; }
        [Required]
        public string SubjectGrade { get; set; }
        [Required]
        public string SubjectGradeHead { get; set; }

    }
}
