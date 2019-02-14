using System;
using System.ComponentModel.DataAnnotations;

namespace Online_Shop.Models
{
    public class LoginUser
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Display(Name = "Remember me")]
        public bool RememberMe  { get; set; }

        public LoginUser()
        {
        }
    }
}
