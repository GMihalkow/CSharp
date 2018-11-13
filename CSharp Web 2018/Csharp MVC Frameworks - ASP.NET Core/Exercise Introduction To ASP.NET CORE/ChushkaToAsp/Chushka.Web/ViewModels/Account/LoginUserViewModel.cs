using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Chushka.Web.ViewModels.Account
{
    public class LoginUserViewModel
    {
        [Required(ErrorMessage ="You must enter an username")]
        [StringLength(100, ErrorMessage = "Username length must between 6 and 100 characters", MinimumLength = 6)]
        public string Username { get; set; }

        [Required(ErrorMessage = "You must enter a password")]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "Password length must between 6 and 100 characters", MinimumLength = 6)]
        public string Password { get; set; }
    }
}
