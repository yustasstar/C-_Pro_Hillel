using EventBusPatternDemo;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IEventBus, EventBus>();

builder.Services.AddSingleton<UserNotificationHandler>();

// Для тестирования без запроса вручную
//var serviceProvider = builder.Services.BuildServiceProvider();
//var eventBus = serviceProvider.GetService<IEventBus>();

//// Публикация события
//eventBus.Publish(new UserCreatedEvent
//{
//	UserId = Guid.NewGuid().ToString(),
//	UserName = "ConsoleTestUser"
//});

var app = builder.Build();

// Принудительная инициализация подписчика (один из варинатов, но может быть подписчиком другой микросервис)
using (var scope = app.Services.CreateScope())
{
	var serviceProvider = scope.ServiceProvider;
	serviceProvider.GetRequiredService<UserNotificationHandler>();
}

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
