using BlogWithDb.Models;
using BlogWithDb.Services;
using DataAccess;
using DataAccess.Entities;
using DataAccess.Repositorys;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogWithDb.Controllers
{
    public class BlogController : Controller
    {
        private readonly IGenericCRUDService<PostResponseModel, PostRegisterModel> _postSvc;
        public BlogController(IGenericCRUDService<PostResponseModel, PostRegisterModel> postSvc)
        {
            _postSvc = postSvc;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _postSvc.Get();
            return View(result);
        }
        public async Task<IActionResult> Read(int id)
        {
            var data = await _postSvc.Get(id);
            return View("Read", data);
        }
        public IActionResult Post()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Post(PostRegisterModel post)
        {
            if (!ModelState.IsValid)
                return View();
            await _postSvc.Create(post);

            return View();
        }
        public async Task<IActionResult> Edit(int id)
        {
            var post = await _postSvc.Get(id);
            return View(post);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, PostResponseModel post)
        {
            await _postSvc.Update(id, post);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int id)
        {
            await _postSvc.Delete(id);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult UploadImage(List<IFormFile> files)
        {
            var filepath = "";
            foreach(IFormFile photo in Request.Form.Files)
            {
                string serverMapPath = Path.Combine("Image", photo.FileName);
                using (var stream = new FileStream(serverMapPath, FileMode.Create))
                {
                    photo.CopyTo(stream);
                }
                filepath = "https://localhost://251" + "Image/" + photo.FileName;
            }
            return Json(new {url = filepath});
        }


    }
}
