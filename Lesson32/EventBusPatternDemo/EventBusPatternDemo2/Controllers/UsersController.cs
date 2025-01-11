using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace EventBusPatternDemo2.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class UsersController : ControllerBase
	{
		private readonly IPublishEndpoint _publishEndpoint;

		public UsersController(IPublishEndpoint publishEndpoint)
		{
			_publishEndpoint = publishEndpoint;
		}

		[HttpPost]
		public async Task<IActionResult> CreateUser(string userName)
		{
			var userId = Guid.NewGuid().ToString();

			// Публикация события
			await _publishEndpoint.Publish(new UserCreatedEvent
			{
				UserId = userId,
				UserName = userName
			});

			Console.WriteLine($"Event published: New user created - {userName} (ID: {userId})");

			return Ok(new { UserId = userId });
		}
	}
}
