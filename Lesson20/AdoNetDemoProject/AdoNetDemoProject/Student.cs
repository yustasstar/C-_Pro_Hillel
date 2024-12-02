using System.ComponentModel.DataAnnotations;

namespace AdoNetDemoProject
{
    public record Student
    {
        public int Id { get; set; }

        [Required]
        public string UserName { get; set; }

        public string Email { get; set; } = string.Empty;

        [Required]
        public string Phone { get; set; }
    }
}
