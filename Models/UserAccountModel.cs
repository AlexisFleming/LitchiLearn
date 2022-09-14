using System.ComponentModel.DataAnnotations;

namespace Final_LitchiLearn.Models
{
    public class UserAccountModel
    {
        [Key]
        public int UserID { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string Surname { get; set; }

        public string Active { get; set; }
        [Required]
        public string Usertype { get; set; }


    }
}
