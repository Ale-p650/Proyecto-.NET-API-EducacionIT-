using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entidades
{
    public class Pais
    {
        public Pais()
        {
            this.Albums = new List<Album>();
            this.Artistas = new List<Artista>();
        }

        public int ID { get; set; }

        [Required]
        public string NombrePais { get; set; }


        public ICollection<Album>? Albums { get; set; }
        public ICollection<Artista>? Artistas { get; set; }
    }
}
