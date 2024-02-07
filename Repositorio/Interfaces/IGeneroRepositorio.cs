using Model.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Interfaces
{
    public interface IGeneroRepositorio
    {
        Task CrearGenero(Genero g);

        Task<List<Genero>> GetGeneros();

        Task<Genero> GetGeneroByID(int id);

        Task<bool> RemoveGenero(int id);

        Task<bool> UpdateGenero(int id, string nuevoNombreGenero);
    }
}
