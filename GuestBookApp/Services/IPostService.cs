using System;
using System.Linq;
using GuestBookApp.Models;

namespace GuestBookApp.Services
{
    public interface IPostService
    {
        IQueryable<Post> GetPostListDescending();
        void SavePostToDb(Post post);
        Post GetPost(Guid id);
        void DeletePost(Post post);
    }
}