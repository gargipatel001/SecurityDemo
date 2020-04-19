using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LoginAssignment.Models
{
    public class ForgotPasswordModel
    {
        [Required]
        [EmailAddress]
        public string Username { get; set; }
        [Required]
        [Display(Name = "New Password")]
        public string NewPassword { get; set; }
        [Required]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }
    }
}