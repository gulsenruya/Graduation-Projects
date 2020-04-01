using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShoppingCome_491.Models
{
    public class Login
    {
        [Required] //bir deger girmek zorunda 
        [DisplayName("User Name")]
        public string UserName { get; set; }

        [Required] //bir deger girmek zorunda 
        [DisplayName("Password")]
        public string Password { get; set; }

        [Required] //bir deger girmek zorunda 
        [DisplayName("Remember Me")]
        public bool RememberMe { get; set; }
    }
}