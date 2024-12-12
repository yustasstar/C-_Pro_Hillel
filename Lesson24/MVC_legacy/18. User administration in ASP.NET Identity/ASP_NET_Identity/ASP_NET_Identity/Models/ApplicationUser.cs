using Microsoft.AspNet.Identity.EntityFramework;

namespace ASP_NET_Identity.Models
{
    // IdentityUser дает базовые представления о пользователе, 
    // которые могут быть расширены путем добавления свойств в производный класс
    public class ApplicationUser : IdentityUser
    {
        public int BirthYear { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public ApplicationUser()
        {
        }
    }
}