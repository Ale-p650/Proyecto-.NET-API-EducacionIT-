using Microsoft.EntityFrameworkCore;
using Model.Entidades;
using Model.DTO;
using Repositorio.Interfaces;
using Repositorio.Metodos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Clases_Servicio
{
    public class ArtistaREPO : IArtistaRepositorio
    {
        #region ctor

        private readonly DbContextOptions<AppDBContext> _options;

        public ArtistaREPO(DbContextOptions<AppDBContext> options)
        {
            _options = options;
        }

        #endregion

        public async Task CreateAsync(Artista artista)
        {
            using(var context= new AppDBContext(_options))
            {
                context.Artistas.Add(artista);
                await context.SaveChangesAsync();
            }
        }

        

        public async Task<List<Artista>> GetAllAsync()
        {
            using (var context = new AppDBContext(_options))
            {
                var result = await context.Artistas.ToListAsync();
                return result;
            }
        }

        public async Task<Artista> GetByIDAsync(int id)
        {
            using (var context = new AppDBContext(_options))
            {
                var result = await context.Artistas.FirstOrDefaultAsync(x => x.ID == id);
                return result;
            }
        }

        public async Task<List<Artista>> GetByPais(int id)
        {
            using (var context = new AppDBContext(_options))
            {
                var result = await context.Artistas.Where(x => x.PaisID == id).ToListAsync();
                return result;
            }
        }

        

        public async Task<List<ArtistaDTOGet>> GetDTOAllAsync()
        {
            using (var context = new AppDBContext(_options))
            {

                var query = from artista in context.Artistas
                            select new ArtistaDTOGet(artista);

                return query.ToList();
            }
            
        }

        public async Task<bool> RemoveAsync(int id)
        {
            using (var context = new AppDBContext(_options))
            {
                Artista a = new Artista()
                {
                    ID = id
                };
                context.Artistas.Remove(a);
                var x = await context.SaveChangesAsync();
                return x > 0;
            }
        }
    }

    
}
