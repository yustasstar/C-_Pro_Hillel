using EfCoreExamples.ContextV1;
using EfCoreExamples.ContextV2;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<FirstInternetShopDbContext>(options =>
								options.UseSqlServer(builder.Configuration.GetConnectionString("FirstConnection")));
builder.Services.AddDbContext<SecondInternetShopDbContext>(options =>
								options.UseSqlServer(builder.Configuration.GetConnectionString("SecondConnection")));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI(c =>
	{
		c.SwaggerEndpoint("v1/swagger.json", "Test API V1");
		c.OAuthAppName("Test API");
	});
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
