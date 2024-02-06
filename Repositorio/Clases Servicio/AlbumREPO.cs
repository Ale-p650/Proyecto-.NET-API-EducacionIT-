using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Model.DTO;
using Model.Entidades;
using Repositorio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Metodos
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

                foreach(AlbumDTOGet dto in result2)
                {
                    dto.Artista = new ArtistaDTOGetAlbum(context.Artistas.Find(dto.ArtistaID));

                }

                return result2;
            }
        }

        public Task<Album> GetByIDAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> CreateAsync(Album album)
        {
            using(var context = new AppDBContext(this._options))
            {
                context.Albums.Add(album);
                return await context.SaveChangesAsync();
            }
        }

        public Task<int> RemoveAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
