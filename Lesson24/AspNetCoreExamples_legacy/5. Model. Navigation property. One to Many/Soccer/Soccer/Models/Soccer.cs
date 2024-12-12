using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Soccer.Models
{
    public class SoccerContext : DbContext
    {
        public SoccerContext(DbContextOptions<SoccerContext> options)
            : base(options)
        {
        }
        public DbSet<Players> Players { get; set; }
        public DbSet<Teams> Teams { get; set; }
    }

    public class Players
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Position { get; set; }
        public int TeamId { get; set; }
        public Teams Team { get; set; }
    }

    public class Teams
    {
        public Teams()
        {
            this.Players = new HashSet<Players>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Coach { get; set; }
        public ICollection<Players> Players { get; set; }
    }

    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}