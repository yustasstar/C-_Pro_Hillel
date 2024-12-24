using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Models
{
    public class Style
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        public virtual IEnumerable<Film> Films { get; set; } = [];
    }
}
