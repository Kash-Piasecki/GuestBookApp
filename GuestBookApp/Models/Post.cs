using System;

namespace GuestBookApp.Models
{
    public class Post : BaseEntity
    {
        public string Message { get; set; }
        public DateTime DateTime { get; set; }
    }
}