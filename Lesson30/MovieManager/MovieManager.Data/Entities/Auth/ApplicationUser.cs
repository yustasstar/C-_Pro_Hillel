using Microsoft.AspNetCore.Identity;

namespace MovieManager.Data.Entities.Auth
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
