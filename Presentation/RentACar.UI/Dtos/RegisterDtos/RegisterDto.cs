using System.ComponentModel.DataAnnotations;

namespace RentACar.UI.Dtos.RegisterDtos
{
    public class RegisterDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Lütfen şifrelerin eşleştiğinden emin olunuz.")]
        public string ConfirmPassword { get; set; }
    }
}
