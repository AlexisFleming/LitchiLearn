using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Final_LitchiLearn.Models
{
    public class AccountRequestModel
    {
        [Key]
        public int RequestID { get; set; }
     
        [Required]     
        public string RequestUsername { get; set; }      

        [Required]
        public string Email { get; set; }

        [Required]
        public string RoleChanged { get; set; }

        [Required]
        public int RequestStatus { get; set; }

    }
}
