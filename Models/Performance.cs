using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Final_LitchiLearn.Models
{
    public class Performance
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }

        [Required]
        public int EngMark { get; set; }
        [Required]
        public int MathMark { get; set; }
        [Required]
        public int TechMark { get; set; }

    }
}
