using Microsoft.EntityFrameworkCore;
using ProyectoIT;
using Repositorio;
using Repositorio.Interfaces;
using Repositorio.Metodos;
using System.Runtime.CompilerServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddMvc().AddJsonOptions
    (options => options.JsonSerializerOptions.ReferenceHandler =
    System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles);


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IAlbumRepositorio, AlbumREPO>();

builder.Services.AddDbContext<AppDBContext>
    (options => options.UseSqlServer
    (Configuration.GetConnectionString()));

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
