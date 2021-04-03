using System.Threading.Tasks;
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
            var postList = _postService.GetPostListDescending();
            var pageSize = 3;
            var pagingListAsync = await PagingList<Post>.CreateAsync(postList, page, pageSize);
            return View(pagingListAsync);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult IndexConfirm(int pageNumber, int maxIndex)
        {
            if (IsPageInRange(pageNumber, maxIndex))
                return Redirect($"Index/?page={pageNumber}");
            return RedirectToAction("Index", "Post");
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

        private bool IsPageInRange(int page, int max)
        {
            return page > 0 && page <= max;
        }
    }
}