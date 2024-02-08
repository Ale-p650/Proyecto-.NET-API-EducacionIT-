using Model.DTO;
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
        Task<Playlist> GetPlaylist(int id,bool like=false);

        Task CrearPlaylist(PlaylistDTOCreate p);
        Task<bool> BorrarPlaylist(int id);

        Task<bool> CambiarNombrePlaylist(int id, string nombre);
        Task<bool> CambiarDescripcionPlaylist(int id, string descripcion);

        Task<string> AgregarCancion(int idCancion, int idPlaylist);
        Task<string> BorrarCancion(int idCancion, int idPlaylist);
    }
}
