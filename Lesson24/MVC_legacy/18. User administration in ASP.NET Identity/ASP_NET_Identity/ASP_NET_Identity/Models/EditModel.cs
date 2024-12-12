using System.ComponentModel.DataAnnotations;

namespace ASP_NET_Identity.Models
{
    public class EditModel
    {
        [Required]
        public int BirthYear { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Country { get; set; }
    }
}