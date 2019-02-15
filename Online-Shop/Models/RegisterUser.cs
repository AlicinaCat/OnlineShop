﻿using System;
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
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$", 
            ErrorMessage = "Must be at least 8 characters and include a number and a special character.")]
        public string Password { get; set; }
        [DisplayName("Full name")]
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }
        [DisplayName("Address")]
        [Required(ErrorMessage = "Address is required.")]
        public string Address { get; set; }
        [DisplayName("Postal code")]
        [Required(ErrorMessage = "Postal code is required.")]
        public string PostalCode { get; set; }
        [DisplayName("City")]
        [Required(ErrorMessage = "City is required.")]
        public string City { get; set; }
        [DisplayName("Email")]
        public string Email { get; set; }
        [DisplayName("Phone")]
        public string Phone { get; set; }


        public RegisterUser()
        {
        }
    }
}
