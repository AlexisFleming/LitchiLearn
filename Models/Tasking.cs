using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Final_LitchiLearn.Models
{
    public class Tasking
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Date { get; set; }

        [Required]
        public string Status { get; set; }

        [DisplayName("Task Name")]
        [Required]
        public string TaskingName { get; set; }
    }
}
