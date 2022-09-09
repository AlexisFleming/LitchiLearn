using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_LitchiLearn.Models
{
    public class ApplicationUser : IdentityUser
    {
        public int UserID { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string email { get; set; }
        public byte[] ProfilePicture { get; set; }

        public int RoleID { get; set; }
    }
}
