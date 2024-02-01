using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entidades
{
    public class Album
    {
        public Album()
        {
            this.Generos = new List<Genero>();
            this.Canciones = new List<Cancion>();
        }

        public int ID { get; set; }
        public Tipo? TipoDisco { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Range(1500,2024)]
        public int Año { get; set; }

        public int NumeroTracks { get; set; }

        public int Duracion { get; set; }

        public string PathCover { get; set; }


        public ICollection<Genero>? Generos { get; set; }


        public ICollection<Cancion>? Canciones { get; set; }

        [Required]
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
