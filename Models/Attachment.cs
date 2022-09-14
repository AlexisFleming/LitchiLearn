using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_LitchiLearn.Models
{
    public class Attachment
    {
        [Key]
        public int id { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string FileName { set; get; }
        [Column(TypeName = "nvarchar(50)")]
        public string Description { set; get; }
        [Column(TypeName = "varbinary(MAX)")]
        public byte[] attachment { set; get; }
    }
}
