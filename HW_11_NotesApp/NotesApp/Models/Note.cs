using System.ComponentModel.DataAnnotations;

namespace NotesApp.Models
{
    public class Note
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        [DataType(DataType.MultilineText)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MinLength(1)]
        [MaxLength(1024)]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; } = string.Empty;

        [Display(Name = "Created At")]
        [Editable(false)]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Display(Name = "Last Updated")]
        [Editable(false)]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public string? Tags { get; set; } //= string.Empty;
    }
}
