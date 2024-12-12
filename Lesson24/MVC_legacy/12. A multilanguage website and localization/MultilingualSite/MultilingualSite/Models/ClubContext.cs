using System.Data.Entity;

namespace MultilingualSite.Models
{
    public class ClubContext : DbContext
    {
        public DbSet<Club> Clubs { get; set; }
    }
}