using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Final_LitchiLearn.Models
{
    public class UserRolesViewModel
    {
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public IEnumerable<string> Roles { get; set; }
    }
   

    //public class AccountRequestModel
    //{
    //    [Key]
    //    public int RequestID { get; set; }
    //    [ForeignKey("UserId")]
    //    public string AccountID { get; set; }
    //    public virtual UserRolesViewModel UserRoles { get; set; }

    //    [ForeignKey("UserName")]
    //    public string RequestUsername { get; set; }

    //    [ForeignKey("Email")]
    //    public string UserEmail { get; set; }


    //    [Required]
    //    public string RoleChanged { get; set; }

    //    [Required]
    //    public byte[] RequesatStatus { get; set; }
    //}


}
