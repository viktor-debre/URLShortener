using System.ComponentModel.DataAnnotations;

namespace URLShortener.Models.ViewModels
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Not specified email")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Not specified password")]
        [DataType(DataType.Password)]
        [MinLength(4, ErrorMessage = "Password must be more than 4 characters")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password do not match")]
        public string ConfirmPassword { get; set; }
    }
}
