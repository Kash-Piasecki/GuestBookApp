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
            IEnumerable<Post> postList = _db.Posts.OrderByDescending(x => x.DateTime);
            foreach (var obj in postList)
            {
                obj.User = _db.Users.FirstOrDefault(x => x.Id == obj.UserId);
            }

            return View(postList);
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
                var newUser = new User()
                {
                    Email = model.User.Email,
                    Name = model.User.Name,
                };
                _db.Users.Add(newUser);
                _db.Posts.Add(new Post()
                {
                    Message = model.Message,
                    User = newUser,
                });
                _db.SaveChanges();
                return RedirectToAction("Index", "Post");
            }

            return View(model);
        }
    }
}