using Microsoft.EntityFrameworkCore;
using Model.Entidades;
using Repositorio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Clases_Servicio
{
    public class PaisREPO : IPaisRepositorio
    {

        #region ctor

        private readonly DbContextOptions<AppDBContext> _options;

        public PaisREPO(DbContextOptions<AppDBContext> options)
        {
            _options = options;
        }

        #endregion


        
        public async Task CrearPais(Pais p)
        {
            using(var context = new AppDBContext(_options))
            {
                await context.AddAsync(p);
                await context.SaveChangesAsync();
            }
        }

        public async Task<Pais> GetPaisByID(int id)
        {
            using (var context = new AppDBContext(_options))
            {
                return await context.Paises.FirstOrDefaultAsync(x => x.ID == id);
            }
        }

        public async Task<List<Pais>> GetPaises()
        {
            using(var context = new AppDBContext(_options))
            {
                var result = await context.Paises.ToListAsync();
                return result;
            }
        }

        public async Task<bool> RemovePais(int id)
        {
            using (var context = new AppDBContext(_options))
            {
                Pais p = new Pais() { ID = id };
                context.Remove(p);
                var x = await context.SaveChangesAsync();

                return x > 0;
            }
        }

        public async Task<bool> UpdatePais(int id ,string nuevoNombrePais)
        {
            using (var context = new AppDBContext(_options))
            {
                context.Paises.First(x => x.ID == id).NombrePais = nuevoNombrePais;

                var x = await context.SaveChangesAsync();

                return x > 0;
            }
        }
    }
}
