using Microsoft.EntityFrameworkCore;
using RabbitMqDemo.Models;

namespace RabbitMqDemo.Data
{
	public class DbContextDemo : DbContext
	{
		public DbContextDemo(DbContextOptions<DbContextDemo> options) : base(options) { }

		public DbSet<Product> Products { get; set; }
	}
}
