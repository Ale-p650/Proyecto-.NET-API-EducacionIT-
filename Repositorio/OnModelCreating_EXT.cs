using Microsoft.EntityFrameworkCore;
using Model.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
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

            entity.HasMany(a => a.Canciones)
                .WithOne(c => c.Album)
                .HasForeignKey(c => c.AlbumID)
                .OnDelete(deleteBehavior: DeleteBehavior.Restrict);

            entity.HasOne(a => a.Artista)
                .WithMany(ar => ar.Albums)
                .HasForeignKey(a => a.ArtistaID)
                .OnDelete(deleteBehavior: DeleteBehavior.Restrict);





        }
    }
}
