using Model.DTO;
using Model.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Interfaces
{
    public interface IArtistaRepositorio
    {
        Task<List<Artista>> GetAllAsync();

        Task<List<ArtistaDTOGet>> GetDTOAllAsync();

        Task<List<Artista>> GetByPais(int id);

        Task<Artista> GetByIDAsync(int id);


        Task CreateAsync(Artista a);

        Task<bool> RemoveAsync(int id);
    }
}
