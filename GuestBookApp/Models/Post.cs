using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuestBookApp.Models
{
    public class Post : BaseEntity
    {
        public Post() :base()
        {
            DateTime = DateTime.Now;
        }
        public string Message { get; set; }
        public DateTime DateTime { get; set; }
        
        [ForeignKey("User")]
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}