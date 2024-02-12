using Model.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Interfaces
{
    public interface ICancionRepositorio
    {
        Task<bool> CrearCancion(Cancion c);

        Task<List<Cancion>> GetCanciones();

        Task<Cancion> GetCancionByID(int id);

        Task<List<Cancion>> GetCancionByAlbumID(int id);

        Task<List<Cancion>> GetCancionByArtistaID(int id);

        Task<bool> UpdateCancion(Cancion c);

        Task<bool> RemoveCancion(int id);

        // TODO: AgregarCancionAPlaylist

    }
}
