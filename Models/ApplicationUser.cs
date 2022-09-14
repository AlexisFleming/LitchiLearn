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
<<<<<<< HEAD
       // public string email { get; set; }
=======
       
>>>>>>> 0d3452cf1781de6d834b5b936e3accda4e8643c6
        public byte[] ProfilePicture { get; set; }

        public ICollection<UserSubject> UserSubjects { get; set; }
    }

}
