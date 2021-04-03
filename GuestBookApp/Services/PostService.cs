using System.Linq;
using GuestBookApp.Data;
using GuestBookApp.Models;

namespace GuestBookApp.Services
{
    public class PostService : IPostService
    {
        private readonly GuestBookContext _db;

        public PostService(GuestBookContext db)
        {
            _db = db;
        }

        public IQueryable<Post> GetPostListDescending()
        {
            var list = _db.Posts.OrderByDescending(x => x.DateTime);
            foreach (var obj in list)
            {
                obj.User = AssignUserByPost(obj);
            }

            return list;
        }

        public void SavePostToDb(Post post)
        {
            var newUser = new User()
            {
                Email = post.User.Email,
                Name = post.User.Name,
            };
            _db.Users.Add(newUser);
            _db.Posts.Add(new Post()
            {
                Message = post.Message,
                User = newUser,
            });
            _db.SaveChanges();
        }

        private User AssignUserByPost(Post post)
        {
            return _db.Users.FirstOrDefault(x => x.Id == post.UserId);
        }
    }
}