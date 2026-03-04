using HotelProject.WebUI.Dtos.ServiceDto;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using HotelProject.WebUI.Dtos.BookingDto;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
    public class BookingAdminController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BookingAdminController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:25024/api/Booking");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBookingDto>>(jsonData);
                return View(values);
            }

            return View();
        }
        public async Task<IActionResult> ApprovedReservation(int id)
        {
            var client = _httpClientFactory.CreateClient();
            await client.GetAsync($"http://localhost:25024/api/Booking/BookingStatusChangeApproved/{id}");
            return RedirectToAction("Index");

        }

        public async Task<IActionResult> CancelledReservation(int id)
        {
            var client = _httpClientFactory.CreateClient();
            await client.GetAsync($"http://localhost:25024/api/Booking/BookingStatusChangeCancelled/{id}");
            return RedirectToAction("Index");

        }
    }
}
