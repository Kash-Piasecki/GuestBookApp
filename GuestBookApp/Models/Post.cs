using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuestBookApp.Models
{
    public class Post : BaseEntity
    {
        public Post() :base()
        {
            DateTime = DateTime.Now;
        }
        
        [Required]
        [MinLength(10, ErrorMessage = "Minimum length is 10 characters.")]
        public string Message { get; set; }
        public DateTime DateTime { get; init; }
        
        [ForeignKey("User")]
        public Guid UserId { get; set; }
        public User User { get; set; }

    }
}