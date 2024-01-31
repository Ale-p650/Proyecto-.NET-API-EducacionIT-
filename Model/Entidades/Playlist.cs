using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entidades
{
    public class Playlist
    {
        public int ID { get; set; }
        public int UsuarioID { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int NumeroTracks { get; set; }
        public int Duracion { get; set; }
        public int Likes { get; set; }

        public IEnumerable<Cancion> Canciones { get; set; }



    }
}
