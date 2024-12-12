using System.Data.Entity;

namespace WebAPISample.Models
{
    public class StudentContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
    }
}