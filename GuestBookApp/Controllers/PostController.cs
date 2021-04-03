using System.Collections.Generic;
using System.Linq;
using GuestBookApp.Data;
using GuestBookApp.Models;
using GuestBookApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace GuestBookApp.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        // GET
        public IActionResult Index()
        {
            return View(_postService.GetPostListDescending());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Post model)
        {
            if (ModelState.IsValid)
            {
               _postService.SavePostToDb(model);
                return RedirectToAction("Index", "Post");
            }
            return View(model);
        }
    }
}