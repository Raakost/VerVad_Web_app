using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceGateways
{
    public enum Role
    {
        Medarbejder, Afdelingsleder, Administrator
    }
    class User
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [RegularExpression("^(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9])(?=.*[!#¤%&/()=?@£$€{}*^|<>§]).{8,24}$",
            ErrorMessage = "Koden skal indeholde 1 symbol, 1 numerisk værdig, 1 stort bogstav, 1 lille bogstav, og være minimun 8 karakterer i længde.")]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public Role Role { get; set; }

    }
}
