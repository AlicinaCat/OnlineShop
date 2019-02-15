using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Online_Shop.Models
{
    public class RegisterUser
    {
        [DisplayName("Choose a username")]
        [StringLength(20, ErrorMessage = "Max 20 characters.")]
        [Required(ErrorMessage = "Username is required.")]
        public string Username { get; set; }
        [DisplayName("Choose a password")]
        [StringLength(20, ErrorMessage = "Max 20 characters.")]
        [Required(ErrorMessage = "Password is required.")]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$", 
            ErrorMessage = "Must be at least 8 characters and include a number and a special character.")]
        public string Password { get; set; }
        [DisplayName("Full name")]
        [StringLength(50, ErrorMessage = "Max 50 characters.")]
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }
        [DisplayName("Address")]
        [StringLength(50, ErrorMessage = "Max 50 characters.")]
        [Required(ErrorMessage = "Address is required.")]
        public string Address { get; set; }
        [DisplayName("Postal code")]
        [StringLength(10, ErrorMessage = "Max 10 characters.")]
        [Required(ErrorMessage = "Postal code is required.")]
        public string PostalCode { get; set; }
        [DisplayName("City")]
        [StringLength(20, ErrorMessage = "Max 20 characters.")]
        [Required(ErrorMessage = "City is required.")]
        public string City { get; set; }
        [DisplayName("Email")]
        [StringLength(50, ErrorMessage = "Max 50 characters.")]
        public string Email { get; set; }
        [DisplayName("Phone")]
        [StringLength(15, ErrorMessage = "Max 15 characters.")]
        public string Phone { get; set; }


        public RegisterUser()
        {
        }
    }
}
