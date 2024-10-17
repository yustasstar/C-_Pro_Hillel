using DependencyInversionPrinciple.MessageInterface;

namespace DependencyInversionPrinciple.Message
{
	public class Sms : IMessage
	{
		public string PhoneNumber { get; set; }

		public string Message { get; set; }

		public string SendMessage()
		{
			var message = string.Empty;

			message += $"---Sms---\n";
			message += $"Phone: {PhoneNumber}\n";
			message += $"Message: {Message}\n";

			return message;
		}
	}
}
