using Gym_Proyect.Context;
using Gym_Proyect.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

// Configura DbContext con la cadena de conexión a SQL Server
var connectionString = builder.Configuration.GetConnectionString("Connection");
builder.Services.AddDbContext<GymDBContext>(options => options.UseSqlServer(connectionString));

// Registro de servicio singleton para mantener el estado de la base de datos
builder.Services.AddSingleton<IDbStatusService, DbStatusService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<GymDBContext>();
    var dbStatusService = scope.ServiceProvider.GetRequiredService<IDbStatusService>();
    try
    {
        var canConnect = dbContext.Database.CanConnect(); // Verifica la conexión
        if (canConnect)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("✅ Conexión a la base de datos establecida correctamente.");
            Console.ResetColor();
            dbStatusService.Status = "✅ Conexión a la base de datos establecida correctamente.";
        }
        else
        {
            throw new Exception("No se pudo establecer la conexión a la base de datos.");
        }
    }
    catch (Exception ex)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("❌ Error al conectar con la base de datos: " + ex.Message);
        Console.ResetColor();
        dbStatusService.Status = "❌ Error al conectar con la base de datos: " + ex.Message;
    }
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

// Endpoint en la raíz ("/") para ver el estado de la conexión en Swagger
app.MapGet("/", (IDbStatusService dbStatusService) =>
{
    return Results.Ok(new { Status = dbStatusService.Status });
}).Produces(200, typeof(object));

app.Run();

// Interfaz para el servicio de estado de la base de datos
public interface IDbStatusService
{
    string Status { get; set; }
}

// Implementación del servicio de estado de la base de datos
public class DbStatusService : IDbStatusService
{
    public string Status { get; set; } = "⏳ Verificando conexión a la base de datos...";
}
