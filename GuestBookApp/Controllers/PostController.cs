using System.Collections.Generic;
using System.Linq;
using GuestBookApp.Data;
using GuestBookApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace GuestBookApp.Controllers
{
    public class PostController : Controller
    {
        private readonly GuestBookContext _db;

        public PostController(GuestBookContext db)
        {
            _db = db;
        }
        
        // GET
        public IActionResult Index()
        {
            IEnumerable<Post> postList = _db.Posts;
            foreach (var obj in postList)
            {
                obj.User = _db.Users.FirstOrDefault(x => x.Id == obj.UserId);
            }
            return View(postList);
        }
    }
}