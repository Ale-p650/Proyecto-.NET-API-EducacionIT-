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
    public class GeneroREPO : IGeneroRepositorio
    {
        #region ctor

        private readonly DbContextOptions<AppDBContext> _options;

        public GeneroREPO(DbContextOptions<AppDBContext> options)
        {
            _options = options;
        }

        #endregion


        public async Task<bool> CrearGenero(Genero g)
        {
            using(var context = new AppDBContext(_options))
            {
                context.Generos.Add(g);
                var x = await context.SaveChangesAsync();
                return x > 0;
            }
        }

        public async Task<Genero> GetGeneroByID(int id)
        {
            using (var context = new AppDBContext(_options))
            {
                return await context.Generos.FirstOrDefaultAsync(x => x.ID == id);
            }
        }

        public async Task<List<Genero>> GetGeneros()
        {
            using (var context = new AppDBContext(_options))
            {
                var x = await context.Generos.ToListAsync();
                return x;
            }
        }

        public async Task<bool> RemoveGenero(int id)
        {
            Genero g = new Genero()
            {
                ID = id
            };

            using (var context = new AppDBContext(_options))
            {
                context.Generos.Remove(g);
                var x = await context.SaveChangesAsync();

                return x > 0;

            }
        }

        public async Task<bool> UpdateGenero(int id, string nuevoNombreGenero)
        {
            using (var context = new AppDBContext(_options))
            {
                context.Generos.First(x => x.ID == id).NombreGenero = nuevoNombreGenero;
                var x = await context.SaveChangesAsync();
                return x > 0;
            }
        }
    }
}
