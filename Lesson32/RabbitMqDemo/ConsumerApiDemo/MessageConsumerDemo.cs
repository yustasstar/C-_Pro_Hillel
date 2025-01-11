using Microsoft.AspNetCore.Connections;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace ConsumerApiDemo
{
	public class MessageConsumerDemo
	{
		private readonly IConfiguration _configuration;

		public MessageConsumerDemo(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public void StartConsuming()
		{
			var factory = new ConnectionFactory()
			{
				HostName = _configuration["RabbitMQ:HostName"],
				Port = int.Parse(_configuration["RabbitMQ:Port"]),
				UserName = _configuration["RabbitMQ:UserName"],
				Password = _configuration["RabbitMQ:Password"]
			};

			using (var connection = factory.CreateConnection())
			using (var channel = connection.CreateModel())
			{
				channel.QueueDeclare(queue: "product", durable: false, exclusive: false, autoDelete: false, arguments: null);
				var consumer = new EventingBasicConsumer(channel);
				consumer.Received += (sender, args) =>
				{
					var body = args.Body.ToArray();
					var message = Encoding.UTF8.GetString(body);
					Console.WriteLine(message);
				};

				channel.BasicConsume(queue: "product", autoAck: true, consumer: consumer);
				Console.WriteLine("Consumer started...");
			}
		}
	}
}
