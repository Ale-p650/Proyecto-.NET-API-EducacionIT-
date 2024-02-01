using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entidades
{
    public class Playlist
    {
        public Playlist()
        {
            this.Canciones = new List<Cancion>();
        }

        public int ID { get; set; }

        [Required]
        public int UsuarioID { get; set; }
        
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int NumeroTracks { get; set; }
        public int Duracion { get; set; }
        public int Likes { get; set; }

        public ICollection<Cancion> Canciones { get; set; }



    }
}
