using System.ComponentModel.DataAnnotations;

namespace WebApiDapperDemo.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        [StringLength(255)]
        public string Address { get; set; }
        [Required]
        [StringLength(50)]
        public string Phone { get; set; }
    }
}
