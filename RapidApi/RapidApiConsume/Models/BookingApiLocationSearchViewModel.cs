using System.Collections.Generic;

namespace RapidApiConsume.Models
{
    public class BookingApiLocationSearchViewModel
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
            public Property property { get; set; }
        }

        public class Property
        {
            public string name { get; set; }
            public double reviewScore { get; set; }
            public long ufi { get; set; }  // ← dest_id burası
        }

    }
}
