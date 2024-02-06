using Model.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Interfaces
{
    public interface IPaisRepositorio
    {
        Task CrearPais(Pais p);

        Task<List<Pais>> GetPaises();

        Task<Pais> GetPaisByID(int id);

        Task<bool> RemovePais(int id);

        Task<bool> UpdatePais(int id ,string nuevoNombrePais);
    }
}
