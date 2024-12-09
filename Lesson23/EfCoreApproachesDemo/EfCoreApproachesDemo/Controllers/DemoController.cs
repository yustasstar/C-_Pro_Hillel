using EfCoreExamples.ContextV1;
using EfCoreExamples.ContextV1.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EfCoreExamples.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DemoController : ControllerBase
	{
		private readonly FirstInternetShopDbContext _firstInternetShopDbContext;

		public DemoController(FirstInternetShopDbContext firstInternetShopDbContext) {
			_firstInternetShopDbContext = firstInternetShopDbContext;
		}

		[HttpGet]
		public async Task<IActionResult> GetProducts(CancellationToken token)
		{
			var products = await _firstInternetShopDbContext.Products.AsNoTracking().Include(x => x.Categories).ToListAsync(token);
			if (products == null)
			{
				return StatusCode(StatusCodes.Status204NoContent, "No categories in database.");
			}

			return StatusCode(StatusCodes.Status200OK, products);
		}
	}
}
