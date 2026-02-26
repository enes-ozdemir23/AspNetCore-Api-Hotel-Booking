using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DtoLayer.Dtos.RoomDto
{
    public class UpdateRoomDto
    {
        public int RoomID { get; set; }

        [Required(ErrorMessage = "Lütfen oda numarasını yazınız")]
        public string RoomNumber { get; set; }

        [Required(ErrorMessage = "Lütfen oda görselini ekleyiniz")]
        public string RoomCoverImage { get; set; }


        [Required(ErrorMessage = "Lütfen fiyat bilgisi yazınız")]
        public int Price { get; set; }

        [Required(ErrorMessage = "Lütfen oda başlığı bilgisini yazınız")]
        [StringLength(100,ErrorMessage ="Lütfen açıklamayı en fazla 100 karakter olarak yazınız")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Lütfen yatak sayısını yazınız")]

        public string BedCount { get; set; }

        [Required(ErrorMessage = "Lütfen banyo sayısını yazınız")]

        public string BathCount { get; set; }

        public string Wifi { get; set; }

        [Required(ErrorMessage = "Lütfen açıklamayı yazınız")]
        public string Description { get; set; }
    }
}
