using Microsoft.EntityFrameworkCore;
using Model.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Clases_Servicio
{
    public class MiddlewareLogsREPO
    {
        private readonly DbContextOptions<AppDBContext> _options;

        public MiddlewareLogsREPO(DbContextOptions<AppDBContext> options)
        {
            _options = options;
        }

        public async Task<int> InsertAsync(MiddlewareLogs log)
        {
            using(var context = new AppDBContext(_options))
            {
                await context.MiddlewareLogs.AddAsync(log);
                return await context.SaveChangesAsync();
            }
        }

        public async Task<List<MiddlewareLogs>> GetAsync()
        {
            using (var context = new AppDBContext(_options))
            {
                return await context.MiddlewareLogs.ToListAsync();
            }
        }
    }
}
