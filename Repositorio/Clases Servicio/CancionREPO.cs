using Microsoft.EntityFrameworkCore;
using Model.Entidades;
using Repositorio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Clases_Servicio
{
    public class CancionREPO : ICancionRepositorio
    {
        private readonly DbContextOptions<AppDBContext> _options;

        public CancionREPO(DbContextOptions<AppDBContext> options)
        {
            _options = options;
        }

        public async Task<bool> CrearCancion(Cancion c)
        {
            using (var context = new AppDBContext(this._options))
            {
                context.Canciones.Add(c);
                var x = await context.SaveChangesAsync();
                return x > 0;
            }
        }

        public async Task<List<Cancion>> GetCancionByAlbumID(int id)
        {
            using (var context = new AppDBContext(this._options))
            {
                var result = context.Canciones.Where(x => x.AlbumID == id).ToListAsync();
                return await result;
            }
        }

        public async Task<List<Cancion>> GetCancionByArtistaID(int id)
        {
            using (var context = new AppDBContext(this._options))
            {
                var result = context.Canciones.Where(x => x.ArtistaID == id).ToListAsync();
                return await result;
            }
        }

        public async Task<Cancion> GetCancionByID(int id)
        {
            using (var context = new AppDBContext(this._options))
            {
                var result = context.Canciones.FirstOrDefaultAsync(x => x.ID == id);
                return await result;
            }
        }

        public async Task<List<Cancion>> GetCanciones()
        {
            using (var context = new AppDBContext(this._options))
            {
                var result = context.Canciones.ToListAsync();
                return await result;
            }
        }

        public async Task<bool> RemoveCancion(int id)
        {
            using (var context = new AppDBContext(this._options))
            {
                Cancion c = new Cancion() { ID = id };

                context.Canciones.Remove(c);
                var result = await context.SaveChangesAsync();
                return result > 0;
            }
        }

        public Task<bool> UpdateCancion(Cancion c)
        {
            using (var context = new AppDBContext(this._options))
            {
                throw new NotImplementedException();
            }
        }
    }
}
