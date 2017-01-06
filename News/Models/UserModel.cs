using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace News.Models
{
    public class UserModel
    {

        public int UserId { get; set; }

        [Display(Name = "FirstName")]
        [Required(ErrorMessage = "Name required!")]
        public string FirstName { get; set; }

        [Display(Name = "LastName")]
        [Required(ErrorMessage = "Name required!")]
        public string LastName { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email required!")]
        [EmailAddress(ErrorMessage = "Not valid!")]
        public string Email { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password required!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [Required(ErrorMessage = "Password not match!")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Birth Date")]
        [Required(ErrorMessage = "Birth Date required!")]
        public DateTime BirthDate { get; set; }
    }
}