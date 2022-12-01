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
        public IActionResult Post()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Post(PostsModel post)
        {
            if (!ModelState.IsValid)
                return View();
            await _postSvc.Create(post);

            return View(post);
        }

    }
}
