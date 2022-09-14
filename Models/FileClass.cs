using System.Collections.Generic;
using System.Linq;

namespace Final_LitchiLearn.Models
{
    public class FileClass
    {
        public int FieldID { get; set; } = 0;
        public string Name { get; set; } = "";
        public string Path { get; set; } = "";
        public List<FileClass> files { get; set; } = new List<FileClass>();
    }
}
