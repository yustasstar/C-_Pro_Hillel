using System.ComponentModel.DataAnnotations;

namespace ASP_NET_Identity.Models
{
    // класс модели-представления (view-model)
    public class RegisterModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public int BirthYear { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        [DataType(DataType.Password)]
        public string PasswordConfirm { get; set; }
    }
}