using Microsoft.EntityFrameworkCore;
using Model.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio
{
    internal static class OnModelCreating_EXT
    {
        public static void ConfigAlbum(this ModelBuilder mb)
        {
            var entity = mb.Entity<Album>();

            entity.ToTable("Albums", "dbo")
                .HasKey(x => x.ID);

            entity.HasMany(a => a.Generos)
                  .WithMany(g => g.Albums)
                  .UsingEntity<AlbumsGeneros>();


            entity.HasOne(a => a.Artista)
                .WithMany(ar => ar.Albums)
                .HasForeignKey(a => a.ArtistaID)
                .OnDelete(deleteBehavior: DeleteBehavior.Restrict);





        }

        public static void ConfigArtista(this ModelBuilder mb)
        {
            var entity = mb.Entity<Artista>();

            entity.ToTable("Artistas", "dbo")
                .HasKey(x => x.ID);

            entity.HasOne(a => a.Pais)
                .WithMany(p => p.Artistas)
                .HasForeignKey(a => a.PaisID)
                .OnDelete(deleteBehavior: DeleteBehavior.Restrict);
        }

        public static void ConfigAlbumsGeneros(this ModelBuilder mb)
        {
            var entity = mb.Entity<AlbumsGeneros>();

            entity.ToTable("AlbumsGeneros", "dbo")
                .HasKey(x => new { x.GeneroID, x.AlbumID });


            


        }

        public static void ConfigCancion(this ModelBuilder mb)
        {
            var entity = mb.Entity<Cancion>();

            entity.ToTable("Canciones", "dbo")
                .HasKey(c=>c.ID);

            entity.HasIndex(c => c.Nombre);

            entity.HasOne(c => c.Album)
                .WithMany(a => a.Canciones)
                .HasForeignKey(c => c.AlbumID)
                .OnDelete(deleteBehavior: DeleteBehavior.Restrict);

            entity.HasOne(c => c.Artista)
                .WithMany(a => a.Canciones)
                .HasForeignKey(c => c.ArtistaID)
                .OnDelete(deleteBehavior: DeleteBehavior.Restrict);

            


        }

        public static void ConfigGeneros(this ModelBuilder mb)
        {
            var entity = mb.Entity<Genero>();

            entity.ToTable("Generos", "dbo")
                .HasKey(c => c.ID);

            entity.HasIndex(c => c.NombreGenero);

            entity.HasMany(c => c.Albums)
            .WithMany(e => e.Generos)
            .UsingEntity<AlbumsGeneros>();




        }

        public static void ConfigPais(this ModelBuilder mb)
        {
            var entity = mb.Entity<Pais>();

            entity.ToTable("Paises", "dbo")
                .HasKey(c => c.ID);

            entity.HasIndex(c => c.NombrePais);

            entity.HasMany(c => c.Artistas)
            .WithOne(e => e.Pais)
            .HasForeignKey(e => e.PaisID);
        }

        public static void ConfigPlaylist(this ModelBuilder mb)
        {
            var entity = mb.Entity<Playlist>();

            entity.ToTable("Playlists", "dbo")
                .HasKey(c => c.ID);

            entity.HasIndex(c => c.UsuarioID);

            
            

        }

        public static void ConfigCancionesPlaylist(this ModelBuilder mb)
        {
            var entity = mb.Entity<CancionesPlaylist>();

            entity.ToTable("CancionesPlaylists", "dbo")
                .HasKey(x => new { x.CancionID, x.PlaylistID });


            


        }
    }
}
