using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MemberLogin.Models.ViewModel
{
    public class LoginModel
    {
        [Required]
        public string Name { set; get; }

        [Required]
        public string Password { set; get; }
    }
}