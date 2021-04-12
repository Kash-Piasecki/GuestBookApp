using System.Diagnostics;
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
        public IActionResult IndexConfirm(int pageNumber)
        {
                return Redirect($"Index/?page={pageNumber}");
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
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}