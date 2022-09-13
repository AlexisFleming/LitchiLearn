using System.ComponentModel.DataAnnotations;

namespace Final_LitchiLearn.Models
{
    public class Subject
    {
        [Key]
        public int SubjectID { get; set; }
        public string SubjectName { get; set; }
        

        

    }
}
