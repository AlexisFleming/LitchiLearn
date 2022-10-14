using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Final_LitchiLearn.Models
{
    public class Topics
    {
        [Key]
        public int TopicID { get; set; }
        public string TopicName { get; set; }
        public string TopicDesc { get; set; }
        [ForeignKey("Subject")]
        public int SubjectID { get; set; }
        
    }
}
