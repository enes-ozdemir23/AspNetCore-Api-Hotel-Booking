using System.Net.Http;
using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using HotelProject.WebUI.Dtos.SocialSubscribeDto;
using Newtonsoft.Json;
using System.Linq;

namespace HotelProject.WebUI.ViewComponents.Dashboard
{
    public class _DashboardSubscribeCountPartial:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://instagram-profile1.p.rapidapi.com/getprofileinfo/murattycedag"),
                Headers =
    {
        { "x-rapidapi-key", "94772ac3eamsh4b856e2a2f33290p1f991bjsn61695af6ea34" },
        { "x-rapidapi-host", "instagram-profile1.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                ResultInstagramFollewersDto resultInstagram = JsonConvert.DeserializeObject<ResultInstagramFollewersDto>(body);
                ViewBag.itakipci = resultInstagram.followers;
                ViewBag.itakip = resultInstagram.following;
                return View();
            }


        }
    }
}
