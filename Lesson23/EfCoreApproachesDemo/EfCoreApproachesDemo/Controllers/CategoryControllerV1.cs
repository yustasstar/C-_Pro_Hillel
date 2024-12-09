using EfCoreExamples.ContextV1;
using EfCoreExamples.ContextV1.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EfCoreExamples.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoryControllerV1 : ControllerBase
	{
		private readonly FirstInternetShopDbContext _firstInternetShopDbContext;

		public CategoryControllerV1(FirstInternetShopDbContext firstInternetShopDbContext) {
			_firstInternetShopDbContext = firstInternetShopDbContext;
		}

		[HttpPost]
		public async Task<IActionResult> GetCategoryAdd(CancellationToken token)
		{
			var cat = new Category
			{
				Name = "first",
				Description = "desc first"
			};

			_firstInternetShopDbContext.Add(cat);

			await _firstInternetShopDbContext.SaveChangesAsync(token);

			return StatusCode(StatusCodes.Status200OK);
		}

		[HttpGet]
		public async Task<IActionResult> GetCategories(CancellationToken token)
		{
			var categories = await _firstInternetShopDbContext.Categories.ToListAsync(token);
			if (categories == null)
			{
				return StatusCode(StatusCodes.Status204NoContent, "No categories in database.");
			}

			return StatusCode(StatusCodes.Status200OK, categories);
		}
	}
}
