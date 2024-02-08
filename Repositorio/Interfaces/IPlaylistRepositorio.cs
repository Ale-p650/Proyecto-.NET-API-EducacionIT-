using Model.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Interfaces
{
    public interface IPlaylistRepositorio
    {
        Task CrearPlaylist(Playlist p);
        Task<bool> BorrarPlaylist(int id);

        Task<bool> CambiarNombrePlaylist(int id, string nombre);

        Task AgregarCancion(int idCancion, int idPlaylist);
        Task BorrarCancion(int idCancion, int idPlaylist);
    }
}
