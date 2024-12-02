using WebApiWithAdoNetDemo.Common;
using WebApiWithAdoNetDemo.Models;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetSection("ConnectionStrings")["DemoDb"].ToString();

// Add services to the container.
var sqlCrudService = new SqlCrudService(connectionString);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.MapGet("/", () => "Students app");
app.MapGet("/api/GetAllStudents", () => sqlCrudService.GetAllStudents());
app.MapPost("/api/PostStudent", (Student student) => sqlCrudService.PostStudent(student));
// Implement methods:
// - GetById
// - Update
// - Delete

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
