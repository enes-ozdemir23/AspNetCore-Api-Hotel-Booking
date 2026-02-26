using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.LoginDto
{
    public class LoginUserDto
    {
        [Required(ErrorMessage ="Kullanıcı Adını Yazınız")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Şifreyi Yazınız")]
        public string Password { get; set; }
    }
}
