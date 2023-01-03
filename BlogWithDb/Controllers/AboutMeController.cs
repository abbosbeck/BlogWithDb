using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogWithDb.Controllers
{
    public class AboutMeController : Controller
    {
        [Authorize]         
        public IActionResult Index()
        {
            return View();
        }
    }
}
