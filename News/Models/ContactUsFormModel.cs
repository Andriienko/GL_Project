using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using  System.ComponentModel.DataAnnotations;

namespace News.Models
{
    public class ContactUsFormModel
    {
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name required!")]
        public string UserName { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email required!")]
        [EmailAddress(ErrorMessage = "Not valid!")]
        public string Email { get; set; }

        [Display(Name = "Coments")]
        public string Coments { get; set; }
    }
}