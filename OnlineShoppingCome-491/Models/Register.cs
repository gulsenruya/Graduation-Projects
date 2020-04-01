using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShoppingCome_491.Models
{
    public class Register
    {
        [Required] //bir deger girmek zorunda 
        [DisplayName("Name")]
        public string Name { get; set; }

        [Required] //bir deger girmek zorunda 
        [DisplayName("Surname")]
        public string SurName { get; set; }

        [Required] //bir deger girmek zorunda 
        [DisplayName("User Name")]
        public string UserName { get; set; }

        [Required] //bir deger girmek zorunda 
        [DisplayName("Email")]
        [EmailAddress(ErrorMessage ="please enter a email true")]
        public string Email { get; set; }

        [Required] //bir deger girmek zorunda 
        [DisplayName("Password")]
        [StringLength(100,ErrorMessage ="7 karakter olmalı",MinimumLength =7)]
        public string Password { get; set; }

        [Required] //bir deger girmek zorunda 
        [DisplayName("RePassword")]
        [Compare("Password",ErrorMessage = "passwords do not match")]
        public string RePassword { get; set; }
    }
}