using EventBusPatternDemo2;
using MassTransit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Добавляем MassTransit
builder.Services.AddMassTransit(x =>
{
	// Конфигурация потребителя (Consumer)
	x.AddConsumer<UserCreatedEventConsumer>();

	// Указываем, какой транспорт использовать (RabbitMQ в данном случае)
	x.UsingRabbitMq((context, cfg) =>
	{
		cfg.Host("localhost", "/", h =>
		{
			h.Username("guest"); // Нужно считать с конфига
			h.Password("guest");
		});

		// Регистрируем конечную точку для потребителя
		cfg.ReceiveEndpoint("user-created-queue", e =>
		{
			e.ConfigureConsumer<UserCreatedEventConsumer>(context);
		});
	});
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

// Как протестировать:

// 1.
// Запуск RabbitMQ брокера сообщений через Docker
// docker run -d --hostname rabbitmq --name rabbitmq -p 5672:5672 -p 15672:15672 rabbitmq:management

// RabbitMQ не хранит историю событий, так как он работает как брокер сообщений, а не как система хранения.
// Сообщения передаются через очереди и, если потребитель их обрабатывает, они удаляются из очереди.

// 2. 
// Запустите приложение WEB API.

// 3. 
// Отправьте POST-запрос:
// curl -X POST http://localhost:5000/api/users -H "Content-Type: application/json" -d "{\"userName\":\"John Doe\"}"
// Или через Swagger.

// 4. 
// Проверьте консоль приложения и убедитесь, что Consumer получил событие:
//Event published: New user created - John Doe (ID: <GUID>)
//Event received: New user created - John Doe (ID: <GUID>)

// 5. 
// Проверьте очереди и статистику в RabbitMQ Management:
// http://localhost:15672/
// Default login and password: guest
