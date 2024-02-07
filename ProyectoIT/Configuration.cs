using Repositorio.Clases_Servicio;
using Repositorio.Interfaces;
using Repositorio.Metodos;

namespace ProyectoIT
{
    public static class Configuration
    {
        public static string GetConnectionString()
        {
            var config = new ConfigurationBuilder().
                SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            var x = config.Build();
            return x.GetConnectionString("Conn");
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IAlbumRepositorio, AlbumREPO>();
            services.AddScoped<IPaisRepositorio, PaisREPO>();
            services.AddScoped<IGeneroRepositorio, GeneroREPO>();
            services.AddScoped<ICancionRepositorio, CancionREPO>();
            services.AddScoped<IArtistaRepositorio, ArtistaREPO>();
        }
    }
}
