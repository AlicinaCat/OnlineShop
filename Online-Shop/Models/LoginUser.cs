using System;
using System.ComponentModel.DataAnnotations;

namespace Online_Shop.Models
{
    public class LoginUser
    {
        [Required(ErrorMessage = "Please fill in the username.")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Please fill in the password.")]
        public string Password { get; set; }
        [Display(Name = "Remember me")]
        public bool RememberMe  { get; set; }

        public LoginUser()
        {
        }
    }
}
