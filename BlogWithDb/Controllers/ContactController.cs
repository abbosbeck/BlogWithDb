using BlogWithDb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogWithDb.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(TelegramMessageModel telegramMessageModel)
        {
            if(telegramMessageModel == null)
                return View();
            string message = $"✅ Sender: {telegramMessageModel.Name}. \nTelegram: {telegramMessageModel.Telegram}. \nSubject: {telegramMessageModel.Subject}. \nMessage: {telegramMessageModel.Message}";
            var uri = new Uri($"https://api.telegram.org/bot5956336067:AAEL8mQkrTEJL2ll5L59CSXao7NFBL1CYpw/sendmessage?text={message}&chat_id=859694843");
            HttpClient client = new HttpClient();
            var response = await client.PostAsync(uri, null);

            return View("Back");
        }
        public string Back()
        {
            return "salom";
        }
    }
}
