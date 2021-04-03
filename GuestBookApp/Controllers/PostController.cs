using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GuestBookApp.Data;
using GuestBookApp.Helper;
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
        public async Task<IActionResult> Index(int page = 1)
        {
            var pagingListAsync = await PagingList<Post>.CreateAsync(_postService.GetPostListDescending(), page, 3);
            return View(pagingListAsync);
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