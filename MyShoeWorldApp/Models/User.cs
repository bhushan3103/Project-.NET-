using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyShoeWorldApp.Models
{
    public class User
    {
        public int UserId { get; set; }
        [Required(ErrorMessage ="Email Id is a required field!")]
        [EmailAddress(ErrorMessage ="Email must be in correct format. For Ex. john@something.com")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is a required field!")]
        [MinLength(6,ErrorMessage ="Password must be minimum 6 characters!")]
        public string Password { get; set; }
        public string Role { get; set; }
    }
}