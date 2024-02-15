using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Model.DTO;
using Model.Entidades;
using Repositorio.Clases_Servicio;
using Repositorio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Clases_Servicio
{
    public class AlbumREPO : IAlbumRepositorio
    {
        #region ctor
        private readonly DbContextOptions<AppDBContext> _options;

        public AlbumREPO(DbContextOptions<AppDBContext> options)
        {
            _options = options;
        }

        #endregion

        

        public async Task<List<Album>> GetAllAsync()
        {
            using(var context = new AppDBContext(this._options)){

                return await context.Albums.Include(a=>a.Artista).ThenInclude(ar=>ar.Pais).ToListAsync();
            }
        }

        public async Task<List<AlbumDTOGet>> GetDTOAllAsync()
        {
            using (var context = new AppDBContext(this._options))
            {
                var result = await context.Albums.ToListAsync();
                var result2 = new List<AlbumDTOGet>();

                foreach(Album a in result)
                {
                    result2.Add(new AlbumDTOGet(a));
                }

                // TODO: traer artista y pais DTO

                return result2;
            }
        }

        public async Task<string> GetByIDAsync(int id)
        {
            using(var context = new AppDBContext(this._options))
            {
                Album? album= await context.Albums.Include
                    (a=>a.Artista).FirstOrDefaultAsync(x => x.ID == id);

                album.Canciones = context.Canciones.Where(c => c.AlbumID == album.ID).ToList();


                var tiempo = TimeSpan.FromSeconds(album.Duracion);

                var base64Image = Convert.ToBase64String(album.Cover);

                var source = String.Format("data:image/png;base64,{0}", base64Image);

                

                StringBuilder sb = new StringBuilder();

                if (album != null)
                {
                    sb.Append("<div>");
                    sb.Append($"<h1>{album.TipoDisco} :  {album.Nombre}<h1>");
                    sb.Append($"<h2>{album.Artista.Nombre}<h2>");
                    sb.Append($"< img src =  \"{source} \"/>");
                    sb.Append($"<h3>Año :{album.Año}<h3>");
                    sb.Append($"<h3>{album.NumeroTracks} Canciones<h3>");
                    sb.Append($"<h3>{tiempo.Minutes.ToString()} minutos<h3>");
                
                    foreach(Cancion c in album.Canciones)
                    {
                        sb.Append($"<h3>#{c.OrdenAlbum}  {c.Nombre}<h1>");
                    }

                    sb.Append("</div>");
                }
                
                return sb.ToString();
            }
        }

        public async Task<Album> CreateAsync(AlbumDTOCreate dto)
        {
            using(var context = new AppDBContext(this._options))
            {
                Album album = new Album();
                album.Nombre = dto.Nombre;
                album.TipoDisco = (Tipo)dto.SetTipo();
                album.Año = dto.Año;
                album.NumeroTracks = dto.Canciones.Count();
                album.Duracion = dto.GetDuracionTotal();
                album.Cover = await dto.CoverDownload(dto.CoverURL);
                album.Generos = dto.CastGeneros();
                album.ArtistaID = dto.ArtistaID;
                album.Canciones = dto.CastCanciones(dto.ArtistaID, (context.Albums.Max(a => a.ID))+1);
                album.PaisID = null;




                context.Albums.Add(album);

                foreach(Cancion c in album.Canciones)
                {
                    context.Canciones.Add(c);
                }

                await context.SaveChangesAsync();
                return album;
            }
        }

        public async Task<int> RemoveAsync(int id)
        {
            Album a = new Album()
            {
                ID = id
            };

            using(var context = new AppDBContext(this._options))
            {
                context.Remove(a);
                return await context.SaveChangesAsync();
            }


        }

        

    }
}
