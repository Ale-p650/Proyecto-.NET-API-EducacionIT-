using Microsoft.EntityFrameworkCore;
using Model.DTO;
using Model.Entidades;
using Repositorio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Clases_Servicio
{
    public class PlaylistRepo : IPlaylistRepositorio
    {
        #region ctor

        private readonly DbContextOptions<AppDBContext> _options;

        public PlaylistRepo(DbContextOptions<AppDBContext> options)
        {
            _options = options;
        }
        #endregion

        public async Task<Playlist> GetPlaylist(int id,bool like=false)
        {
            using (var context = new AppDBContext(_options))
            {
                Playlist? playlist = context.Playlists.FirstOrDefault(x => x.ID == id);
                
                if (playlist != null)
                {
                    if (like)
                    {
                        playlist.Likes++;
                        await context.SaveChangesAsync();

                    }
                            playlist.Canciones = (from cp in context.CancionesPlaylists
                            join c in context.Canciones on cp.CancionID equals c.ID
                            where (cp.PlaylistID == id)
                            select c).ToList();
                }
                    return playlist;
            }
        }

        public async Task<string> AgregarCancion(int idCancion, int idPlaylist)
        {
            using (var context = new AppDBContext(_options))
            {
                Cancion? cancion = await context.Canciones.FirstOrDefaultAsync
                    (x => x.ID == idCancion);

                Playlist? playlist = await context.Playlists.FirstOrDefaultAsync
                    (x => x.ID == idPlaylist);

                playlist.NumeroTracks++;
                playlist.Duracion += cancion.Duracion;

                context.CancionesPlaylists.Add(new CancionesPlaylist()
                { CancionID = cancion.ID, PlaylistID = playlist.ID });

                await context.SaveChangesAsync();

                return cancion.Nombre;

            }
        }

        public async Task<string> BorrarCancion(int idCancion, int idPlaylist)
        {
            using (var context = new AppDBContext(_options))
            {
                Cancion? cancion = await context.Canciones.FirstOrDefaultAsync
                    (x => x.ID == idCancion);

                Playlist? playlist = await context.Playlists.FirstOrDefaultAsync
                    (x => x.ID == idPlaylist);

                playlist.NumeroTracks--;
                playlist.Duracion -= cancion.Duracion;

                context.CancionesPlaylists.Remove(new CancionesPlaylist()
                { CancionID = cancion.ID, PlaylistID = playlist.ID });

                await context.SaveChangesAsync();

                return cancion.Nombre;
            }
        }

        public async Task<bool> BorrarPlaylist(int id)
        {
            using (var context = new AppDBContext(_options))
            {
                Playlist p = new Playlist()
                {
                    ID = id
                };

                context.Playlists.Remove(p);
                var x = await context.SaveChangesAsync();
                return x > 0;
            }
        }

        public async Task<bool> CambiarNombrePlaylist(int id, string nombre)
        {
            using (var context = new AppDBContext(_options))
            {
                context.Playlists.FirstOrDefault(x => x.ID == id).Nombre = nombre;
                var x = await context.SaveChangesAsync();
                return x > 0;
            }
        }

        public async Task<bool> CambiarDescripcionPlaylist(int id, string descripcion)
        {
            using (var context = new AppDBContext(_options))
            {
                context.Playlists.FirstOrDefault(x => x.ID == id).Descripcion = descripcion;
                var x = await context.SaveChangesAsync();
                return x > 0;
            }
        }

        public async Task CrearPlaylist(PlaylistDTOCreate p)
        {
            using(var context = new AppDBContext(_options))
            {
                context.Playlists.Add(p.GetPlaylist());
                await context.SaveChangesAsync();
            }
        }
    }
}
