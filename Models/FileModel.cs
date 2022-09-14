using System.IO;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace Final_LitchiLearn.Models
{
    public class FileModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContentType { get; set; }
        public byte[] Data { get; set; }
    }
}
