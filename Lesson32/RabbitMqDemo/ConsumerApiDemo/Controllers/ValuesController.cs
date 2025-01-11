using Microsoft.AspNetCore.Mvc;

namespace ConsumerApiDemo.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ValuesController : ControllerBase
	{
		private readonly MessageConsumerDemo _messageConsumerDemo;

		public ValuesController(MessageConsumerDemo messageConsumerDemo)
		{
			_messageConsumerDemo = messageConsumerDemo;
		}

		[HttpGet]
		public IActionResult Get()
		{
			_messageConsumerDemo.StartConsuming();

			return Ok();
		}
	}
}
