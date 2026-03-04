using System.Net.Http;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using static RapidApiConsume.Models.BookingApiViewModel;

namespace RapidApiConsume.Controllers
{
    public class BookingController : Controller
    {
        public async Task< IActionResult> Index()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://booking-com15.p.rapidapi.com/api/v1/hotels/searchHotels?dest_id=-755070&search_type=CITY&arrival_date=2026-04-01&departure_date=2026-04-05&adults=1&sort_by=popularity"),
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
                var values = JsonConvert.DeserializeObject<HotelSearchResponse>(body);
                return View(values.data.hotels);

            }
        }
    }
}
