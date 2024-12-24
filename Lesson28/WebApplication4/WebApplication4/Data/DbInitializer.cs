using Microsoft.EntityFrameworkCore;
using WebApplication4.Models;

namespace WebApplication4.Data
{
	public class DbInitializer
	{
		private readonly ModelBuilder _modelBuilder;

		public DbInitializer(ModelBuilder modelBuilder)
		{
			_modelBuilder = modelBuilder;
		}

		public void Seed()
		{
			_modelBuilder.Entity<Director>(x =>
			{
				x.HasData(new Director
				{
					Id = 1,
					Name = "Vasya",
					BirthDate = new DateOnly(1990, 10, 10)
				});
				x.HasData(new Director
				{
					Id = 2,
					Name = "Petya",
					BirthDate = new DateOnly(1991, 11, 11)
				});
				x.HasData(new Director
				{
					Id = 3,
					Name = "Anton",
					BirthDate = new DateOnly(1992, 12, 12)
				});
			});
		}
	}
}
