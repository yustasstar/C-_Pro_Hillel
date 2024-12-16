using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NotesApp.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(25)]
        [Display(Name = "Contact Full Name")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.PhoneNumber)]
        [Phone]
        public string? Phone { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Phone]
        [Display(Name = "Alternative Phone")]
        public string? AlternativePhone { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string? Email { get; set; }

        [MaxLength(255)]
        [DataType(DataType.MultilineText)]
        public string? Description { get; set; } //= string.Empty; //- string will be required
    }
}
