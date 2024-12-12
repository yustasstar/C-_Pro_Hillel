using System.Data.Entity;

namespace StoringPassword.Models
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }
    }
}