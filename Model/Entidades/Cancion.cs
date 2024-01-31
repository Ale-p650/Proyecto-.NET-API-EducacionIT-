using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entidades
{
    public class Cancion
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public int OrdenAlbum { get; set; }
        public int Reproducciones { get; set; }
        public int Duracion { get; set; }


        public int AlbumID { get; set; }
        public Album? Album { get; set; }


        public int ArtistaID { get; set; }
        public Artista? Artista { get; set; }




    }
}
