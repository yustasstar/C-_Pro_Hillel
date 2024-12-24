using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Models
{
    public class Film
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        public int DirectorId { get; set; }

        public virtual Director? Director { get; set; }

        public virtual IEnumerable<Style> Styles { get; set; } = [];

        public virtual IEnumerable<Session> Sessions { get; set; } = [];
    }
}
