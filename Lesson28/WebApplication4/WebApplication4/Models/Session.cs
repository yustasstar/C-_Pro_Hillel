using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Models
{
    public class Session
    {
        public int Id { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public int FilmId { get; set; }

        public Film? Film { get; set; }
    }
}
