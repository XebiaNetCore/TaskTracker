using System;
using System.ComponentModel.DataAnnotations;

namespace TaskTracker.Services.Identity.Model
{
    public class LoginModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public Registration.SystemRole Role { get; set; }
    }
}