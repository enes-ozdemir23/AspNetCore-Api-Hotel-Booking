using HotelProject.WebUI.Models.Mail;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace HotelProject.WebUI.Controllers
{
    public class AdminMail : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(AdminMailViewModel model)
        {
            MimeMessage mimeMessage=new MimeMessage();

            MailboxAddress mailboxAddressFrom = new MailboxAddress("HotelierAdmin", "ozdemir.enes2323@gmail.com");
            mimeMessage.From.Add(mailboxAddressFrom);

            MailboxAddress mailboxAdressTo = new MailboxAddress("User", model.ReceiverMail);
            mimeMessage.To.Add(mailboxAdressTo);

            var bodyBuilder=new BodyBuilder();
            bodyBuilder.TextBody=model.Body;
            mimeMessage.Body=bodyBuilder.ToMessageBody();

            mimeMessage.Subject=model.Subject;
            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587, false);
            client.Authenticate("ozdemir.enes2323@gmail.com", "kohujzavlaqsblkl");
            client.Send(mimeMessage);
            client.Disconnect(true);

            return View();
        }
    }
}
