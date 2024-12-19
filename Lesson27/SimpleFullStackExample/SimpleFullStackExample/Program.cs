using SimpleFullStackExample;

List<Person> users = new()
{
    new() { Id = Guid.NewGuid().ToString(), Name = "Tom", Age = 37 },
    new() { Id = Guid.NewGuid().ToString(), Name = "Bob", Age = 41 },
    new() { Id = Guid.NewGuid().ToString(), Name = "Sam", Age = 24 }
};

var builder = WebApplication.CreateBuilder();
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();
//app.UseSwagger();
//app.UseSwaggerUI();

app.MapGet("/api/users", () => users);

app.MapGet("/api/users/{id}", (string id) =>
{
    Person? user = users.FirstOrDefault(u => u.Id == id);

    if (user == null) 
        return Results.NotFound(new { message = "User not found!" });

    return Results.Json(user);
});

app.MapDelete("/api/users/{id}", (string id) =>
{
    Person? user = users.FirstOrDefault(u => u.Id == id);

    if (user == null) 
        return Results.NotFound(new { message = "User not found!" });

    users.Remove(user);
    return Results.Json(user);
});

app.MapPost("/api/users", (Person user) => {
    user.Id = Guid.NewGuid().ToString();
    users.Add(user);
    return user;
});

app.MapPut("/api/users", (Person userData) => {
    var user = users.FirstOrDefault(u => u.Id == userData.Id);

    if (user == null) 
        return Results.NotFound(new { message = "User not found!" });

    user.Age = userData.Age;
    user.Name = userData.Name;
    return Results.Json(user);
});

app.Run();
