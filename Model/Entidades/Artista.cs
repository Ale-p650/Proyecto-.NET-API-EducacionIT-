using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entidades
{
    public class Artista
    {
        public Artista()
        {
            this.Albums = new List<Album>();
            this.Canciones = new List<Cancion>();

            this.IsVerified = false;
        }

        [Required]
        public int ID { get; set; }

        [Required]
        public string  Nombre { get; set; }
        public int Oyentes { get; set; }
        public bool IsVerified { get; set; }
        public string PathFoto { get; set; }
        public string Descripcion { get; set; }

        [Required]
        public int PaisID { get; set; }
        public Pais? Pais { get; set; }

        public ICollection<Album> Albums { get; set; } 

        public ICollection<Cancion> Canciones { get; set; }



    }
}
