using Microsoft.EntityFrameworkCore;
using Model.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Clases_Servicio
{
    public class FiltroLogsREPO
    {
        private readonly DbContextOptions<AppDBContext> _options;
        public FiltroLogsREPO(DbContextOptions<AppDBContext> options)
        {
            _options = options;
        }

        public async Task<int> InsertAsync(FiltroLogs log)
        {
            using (var context = new AppDBContext(_options))
            {
                await context.FiltroLogs.AddAsync(log);
                return await context.SaveChangesAsync();
            }
        }

        public async Task<List<FiltroLogs>> GetAsync()
        {
            using (var context = new AppDBContext(_options))
            {
                return await context.FiltroLogs.ToListAsync();
            }
        }

    }
}
