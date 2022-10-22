using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System;

using System.IO;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace Final_LitchiLearn.Models
{
    

    public class CurriculumModel
    {
        [Key]
        public int CurrID { get; set; }

        [Required]
        public string Grade { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]        
        public byte[] PDFfile { get; set; }
    }

    
}
