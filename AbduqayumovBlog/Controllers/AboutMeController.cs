using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogWithDb.Controllers
{
    public class AboutMeController : Controller
    {   
        public IActionResult Index()
        {
            return View();
        }
    }
}
