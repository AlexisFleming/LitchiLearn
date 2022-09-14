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
       

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public byte[] ProfilePicture { get; set; }

        public ICollection<UserSubject> UserSubjects { get; set; }
    }

}
