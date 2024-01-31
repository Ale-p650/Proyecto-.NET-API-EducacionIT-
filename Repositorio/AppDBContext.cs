using Microsoft.EntityFrameworkCore;
using Model.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio
{
    public class AppDBContext : DbContext
    {
        public AppDBContext()
        {
            
        }

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            
        }

        public DbSet<Album> Albums { get; set; }
        public DbSet<Artista> Artistas { get; set; }
        public DbSet<Cancion> Canciones { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Pais> Paises { get; set; }
        public DbSet<Playlist> Playlists { get; set; }


    }
}
