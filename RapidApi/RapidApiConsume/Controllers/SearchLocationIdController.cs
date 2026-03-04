using System.Net.Http;
using System;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using static RapidApiConsume.Models.BookingApiViewModel;
using System.Threading.Tasks;
using RapidApiConsume.Models;
using System.Collections.Generic;
using System.Linq;

namespace RapidApiConsume.Controllers
{
    public class SearchLocationIdController : Controller
    {
        List<BookingApiLocationSearchViewModel> model=new List<BookingApiLocationSearchViewModel>();
        public async Task< IActionResult> Index(string cityName)
        {
        
            // 1. Önce cityName ile dest_id bul
            string destId = "-755070"; // default Istanbul

            if (!string.IsNullOrEmpty(cityName))
            {
                var destClient = new HttpClient();
                var destRequest = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"https://booking-com15.p.rapidapi.com/api/v1/hotels/searchDestination?query={cityName}"),
                    Headers =
            {
                { "x-rapidapi-key", "94772ac3eamsh4b856e2a2f33290p1f991bjsn61695af6ea34" },
                { "x-rapidapi-host", "booking-com15.p.rapidapi.com" },
            },
                };
                using (var destResponse = await destClient.SendAsync(destRequest))
                {
                    var destBody = await destResponse.Content.ReadAsStringAsync();
                    var destValues = JsonConvert.DeserializeObject<dynamic>(destBody);
                    destId = destValues.data[0].dest_id; // ilk sonucun dest_id'si
                }
            }

            // 2. Bulunan dest_id ile otel ara
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://booking-com15.p.rapidapi.com/api/v1/hotels/searchHotels?dest_id={destId}&search_type=CITY&arrival_date=2026-03-23&departure_date=2026-04-01&adults=2&room_qty=1&currency_code=EUR"),
                Headers =
        {
            { "x-rapidapi-key", "94772ac3eamsh4b856e2a2f33290p1f991bjsn61695af6ea34" },
            { "x-rapidapi-host", "booking-com15.p.rapidapi.com" },
        },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<BookingApiLocationSearchViewModel.HotelSearchResponse>(body);
                return View(values.data.hotels.ToList());
            }
        }
    }
}
