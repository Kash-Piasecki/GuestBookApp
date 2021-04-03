using System.ComponentModel.DataAnnotations;

namespace GuestBookApp.Models
{
    public class User : BaseEntity
    {
        [Required]
        [MinLength(3, ErrorMessage = "Minimum length is 3 characters.")]
        [RegularExpression("^[a-z]*$", ErrorMessage = "Only english letters.")]
        public string Name { get; set; }
        
        [Required]
        [DataType(DataType.EmailAddress)]
        [MinLength(4, ErrorMessage = "Minimum length is 4 characters.")]
        public string Email { get; set; }
    }
}