using GuestBookApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GuestBookApp.Data
{
    public class GuestBookContext : IdentityDbContext
    {
        public GuestBookContext(DbContextOptions<GuestBookContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
    }
}