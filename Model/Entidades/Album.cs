using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entidades
{
    public class Album
    {
        public int ID { get; set; }
        public Tipo? TipoDisco { get; set; }
        public string Nombre { get; set; }
        public int Año { get; set; }
        public int NumeroTracks { get; set; }
        public int Duracion { get; set; }
        public string PathCover { get; set; }


        public IEnumerable<Genero>? Generos { get; set; }


        public IEnumerable<Cancion>? Canciones { get; set; }


        public int ArtistaID { get; set; }
        public Artista? Artista { get; set; }
    }

    public enum Tipo
    {
        Album,
        EP,
        Sencillo
    }
}
