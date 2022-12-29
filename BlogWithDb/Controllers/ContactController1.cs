using Microsoft.AspNetCore.Mvc;

namespace BlogWithDb.Controllers
{
    public class ContactController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
