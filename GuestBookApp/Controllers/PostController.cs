using Microsoft.AspNetCore.Mvc;

namespace GuestBookApp.Controllers
{
    public class PostController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}