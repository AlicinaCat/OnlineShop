using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Online_Shop.Models
{
    public class RegisterUser
    {
        [DisplayName("Choose a username")]
        [Required(ErrorMessage = "Username is required.")]
        public string Username { get; set; }
        [DisplayName("Choose a password")]
        [Required(ErrorMessage = "Password is required.")]
        [RegularExpression("(?=.*[0-9])", ErrorMessage = "The string must contain at least one numeric character.")]
        public string Password { get; set; }

        public RegisterUser()
        {
        }
    }
}
