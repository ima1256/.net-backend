using AccessControlAPI.Data;
using Microsoft.EntityFrameworkCore;
using AccessControlAPI.Models;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Registrar DbContext con SQLite
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Activar Swagger en desarrollo
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    // Eliminar todos los usuarios
    context.Users.RemoveRange(context.Users);
    context.Users.AddRange(
        new User { Name = "Ane", Email = "ane@example.com" },
        new User { Name = "Jon", Email = "jon@example.com" },
        new User { Name = "Maite", Email = "maite@example.com" },
        new User { Name = "Luis", Email = "luis@example.com" },
        new User { Name = "Sara", Email = "sara@example.com" },
        new User { Name = "Carlos", Email = "carlos@example.com" },
        new User { Name = "Marta", Email = "marta@example.com" },
        new User { Name = "Pablo", Email = "pablo@example.com" },
        new User { Name = "Lucía", Email = "lucia@example.com" },
        new User { Name = "David", Email = "david@example.com" }
    );

    context.SaveChanges();

}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
