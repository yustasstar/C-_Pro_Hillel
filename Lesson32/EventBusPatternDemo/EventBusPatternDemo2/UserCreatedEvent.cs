namespace EventBusPatternDemo2
{
	public class UserCreatedEvent
	{
		public string UserId { get; set; } = string.Empty;
		public string UserName { get; set; } = string.Empty;
	}
}
