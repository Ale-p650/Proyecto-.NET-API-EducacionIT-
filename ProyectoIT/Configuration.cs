using Repositorio.Clases_Servicio;
using Repositorio.Interfaces;

namespace ProyectoIT
{
    public enum Origen
    {
        BBDD,
        Archivo
    }

    public static class Configuration
    {
        private static IServiceProvider _provider;

        public static void SetProvider(IServiceProvider provider)
        {
            _provider = provider;
        }

        public static IServiceProvider GetProvider()
        {
            return _provider;
        }

        public static string GetConnectionString()
        {
            var config = new ConfigurationBuilder().
                SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            var x = config.Build();
            return x.GetConnectionString("Conn");
        }

        public static void AddRepositories(this IServiceCollection services,Origen origen)
        {
            services.AddScoped<IPaisRepositorio, PaisREPO>();
            services.AddScoped<IGeneroRepositorio, GeneroREPO>();
            services.AddScoped<ICancionRepositorio, CancionREPO>();
            services.AddScoped<IArtistaRepositorio, ArtistaREPO>();
            services.AddScoped<IPlaylistRepositorio, PlaylistRepo>();
            services.AddTransient<MiddlewareLogsREPO>();
            services.AddTransient<FiltroLogsREPO>();

            if (origen == Origen.BBDD) services.AddScoped<IAlbumRepositorio, AlbumREPO>();

            else services.AddScoped<IAlbumRepositorio, AlbumFileREPO>(x => new AlbumFileREPO(Environment.CurrentDirectory));
            
        }
    }
}
