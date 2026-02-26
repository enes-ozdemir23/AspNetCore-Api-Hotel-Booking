using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.RegisterDto
{
    public class CreateNewUserDto
    {
        [Required(ErrorMessage ="İsim Alanı Gereklidir")]
        public string Name { get; set; }


        [Required(ErrorMessage = "İsim Alanı Gereklidir")]
        public string SurName { get; set; }


        [Required(ErrorMessage = "Kullanıcı adı Alanı Gereklidir")]
        public string Username { get; set; }


        [Required(ErrorMessage = "Mail Alanı Gereklidir")]
        public string Mail { get; set; }


        [Required(ErrorMessage = "Şifre Alanı Gereklidir")]
        public string Password { get; set; }


        [Required(ErrorMessage = "Şifre Tekrar Alanı Gereklidir")]
        [Compare("Password",ErrorMessage ="Şifreler Eşleşmiyor")]
        public string ConfirmPassword { get; set; }
    }
}
