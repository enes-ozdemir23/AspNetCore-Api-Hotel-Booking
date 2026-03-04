using System.Collections.Generic;

namespace RapidApiConsume.Models
{
    public class BookingApiViewModel
    {
        public class HotelSearchResponse
        {
            public bool status { get; set; }
            public HotelData data { get; set; }
        }

        public class HotelData
        {
            public List<Hotel> hotels { get; set; }
        }

        public class Hotel
        {
            public property property { get; set; }
        }

        public class property
        {
            public string name { get; set; }
            public double reviewScore { get; set; }
        }
    }
}
