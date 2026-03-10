using HotelProject.WebUI.Models.Staff;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using HotelProject.WebUI.Dtos.ContactDto;
using System.Text;
using HotelProject.WebUI.Dtos.SendMessageDto;
using System;
using System.Linq;

namespace HotelProject.WebUI.Controllers
{
    public class AdminContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:25024/api/Contact");

            var client2 = _httpClientFactory.CreateClient();
            var responseMessage2 = await client2.GetAsync("http://localhost:25024/api/Contact/GetContactCount");

            var client3 = _httpClientFactory.CreateClient();
            var responseMessage3 = await client3.GetAsync("http://localhost:25024/api/SendMessage/GetSendMessageCount");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<InboxContactDto>>(jsonData);

                var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                ViewBag.contactCount = jsonData2;

                var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
                ViewBag.messageCount = jsonData3;


                return View(values);
            }

            return View();
        }

        public async Task<IActionResult> SendBox()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:25024/api/SendMessage");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultSendBoxDto>>(jsonData);
                return View(values);
            }



            return View();
        }

        [HttpGet]
        public IActionResult AddSendMessage()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddSendMessage(CreateSendMessage createSendMessage)
        {
            createSendMessage.SenderMail = "admin@gmail.com";
            createSendMessage.SenderName = "admin";
            createSendMessage.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createSendMessage);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:25024/api/SendMessage", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();

        }

        public async Task<PartialViewResult> _SideBarAdminContactPartial()
        {      
     

            return PartialView();
        }

        public PartialViewResult _SideBarAdminContactCategoryPartial()
        {
            return PartialView();

        }

        public async Task< IActionResult > MessageDetailsBySendBox(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:25024/api/SendMessage/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var JsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<GetMessageByIDDto>(JsonData);
                return View(values);
            }
            return View();
        }
        public async Task<IActionResult> MessageDetailsByInbox(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:25024/api/Contact/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var JsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<InboxContactDto>(JsonData);
                return View(values);
            }
            return View();
        }


    }
}
