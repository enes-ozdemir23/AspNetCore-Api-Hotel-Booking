using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.ServiceDto
{
    public class UpdateServiceDto
    {
        public int ServiceID { get; set; }

        [Required(ErrorMessage = "Hizmet ikon linki ekleyiniz")]
        public string ServiceIcon { get; set; }

        [Required(ErrorMessage = "Hizmet başlığı  ekleyiniz")]
        [StringLength(100, ErrorMessage = "Hizmet Başlığı en fazla 100 karakter olabilir")]
        public string Title { get; set; }


        [Required(ErrorMessage = "Hizmet Açıklaması ekleyiniz")]
        [StringLength(500, ErrorMessage = "Hizmet Açıklaması en fazla 100 karakter olabilir")]
        public string Description { get; set; }
    }
}
