using System.ComponentModel.DataAnnotations;

namespace GuestBookApp.Models
{
    public class User : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}