using BlogWithDb.Models;
using BlogWithDb.Services;
using DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace BlogWithDb.Controllers
{
    public class BlogController : Controller
    {
        private readonly IGenericCRUDService<PostsModel> _postSvc;
        public BlogController(IGenericCRUDService<PostsModel> postSvc)
        {
            _postSvc = postSvc;
        }
       // [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _postSvc.Get();
            return View(result);
        }
    }
}
