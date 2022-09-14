using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Final_LitchiLearn.Models
{
    public class AttachmentViewModel
    {
        public string FileName { set; get; }
        public string Description { set; get; }
        public IFormFile attachment { set; get; }
        public List<Attachment> attachments { get; set; }
    }
}
