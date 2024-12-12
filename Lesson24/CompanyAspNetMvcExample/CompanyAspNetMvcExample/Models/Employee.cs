using System.ComponentModel.DataAnnotations;

namespace CompanyAspNetMvcExample.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Employee Name")]
        public string? Name { get; set; }

        public int Age { get; set; }

        [DataType(DataType.MultilineText)]
        public string? Address { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }
    }
}