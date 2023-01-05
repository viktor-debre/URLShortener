using System.ComponentModel.DataAnnotations;

namespace URLShortener.Models.ViewModels
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Not specified login")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Not specified password")]
        [DataType(DataType.Password)]
        [MinLength(4, ErrorMessage = "Password must be more than 4 characters")]
        public string Password { get; set; }
    }
}
