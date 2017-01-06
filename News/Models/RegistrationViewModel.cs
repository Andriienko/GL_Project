using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace News.Models
{
    public  class RegistrationViewModel
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

        [Display(Name = "Birth Date")]
        [Required(ErrorMessage = "Day required!")]
        public int Day { get; set; }

        [Required(ErrorMessage = "Month required!")]
        public int Month { get; set; }

        [Required(ErrorMessage = "Year required!")]
        public int Year { get; set; }

        public RegistrationViewModel(UserModel user)
        {
            UserId = user.UserId;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Email = user.Email;
            Password = user.Password;
            Day = user.BirthDate.Day;
            Month = user.BirthDate.Month;
            Year = user.BirthDate.Year;
        }

        public RegistrationViewModel()
        {
        }
    }
}