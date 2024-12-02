using System.ComponentModel.DataAnnotations;

namespace WebApiWithAdoNetDemo.Models
{
    public record Student
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string UserName { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        public string Phone { get; set;}
    }
}
