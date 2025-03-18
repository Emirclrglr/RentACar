using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json.Serialization;

namespace RentACar.UI.Dtos.LoginDtos
{
    public class LoginDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
