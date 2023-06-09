using Microsoft.EntityFrameworkCore;
using P01_WA.Models;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//Inyeccion por dependecia del string de conexion de contexto
builder.Services.AddDbContext<equiposContext>(options =>
        options.UseSqlServer(
            builder.Configuration.GetConnectionString("string_conexion")
            )
        );

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
