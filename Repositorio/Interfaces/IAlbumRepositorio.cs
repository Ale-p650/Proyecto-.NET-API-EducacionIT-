using Model.DTO;
using Model.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Interfaces
{
    public interface IAlbumRepositorio 
    {
        Task<List<Album>> GetAllAsync();

        Task<List<AlbumDTOGet>> GetDTOAllAsync();

        Task<Album> GetByIDAsync(int id);

        Task CreateAsync(Album album);

        Task<int> RemoveAsync(int id);
    }
}
