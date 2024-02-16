using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Model.DTO;
using Model.Entidades;
using ProyectoIT;
using ProyectoIT.Filtros;
using ProyectoIT.Middlewares;
using Repositorio;
using Repositorio.Clases_Servicio;
using Repositorio.Interfaces;
using System.Runtime.CompilerServices;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer();

builder.Services.AddMvc().AddJsonOptions
    (options => options.JsonSerializerOptions.ReferenceHandler =
    System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles);



builder.Services.AddControllers(

    options => { options.Filters.Add<FiltroExcepcion>(); }

    ) ;

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddRepositories(Origen.BBDD);

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

Configuration.SetProvider(app.Services);



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseAuthentication();

#region Middlewares Practica


app.MetodoLOGS();

//app.UseMiddleware<MiddlewareCustom>();


//app.Use(async (context, next) =>
//{
//    if (context.Request.Method == "GET") await Console.Out.WriteLineAsync
//        ("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");


//    await next.Invoke(context);
//});


//app.Run(async (context) =>
//{
//    await context.Response.WriteAsync("\nMIDDLEWARE run");

//});

#endregion

app.Run();
