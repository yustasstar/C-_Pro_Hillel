using DependencyInversionPrinciple.MessageInterface;

namespace DependencyInversionPrinciple.Message
{
	public class Email : IMessage
	{
		public string ToAddress { get; set; }

		public string Subject { get; set; }

		public string Content { get; set; }

		public string SendMessage()
		{
			string message = string.Empty;

			message += "---Email---\n";
			message += $"Address: {ToAddress}\n";
			message += $"Subject: {Subject}\n";
			message += $"Content: {Content}\n";

			return message;
		}
	}
}
