using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entidades
{
    public class Genero
    {
        public Genero()
        {
            this.Albums = new List<Album>();
        }

        public int ID { get; set; }
        [Required]
        public string NombreGenero { get; set; }

        public ICollection<Album>? Albums { get; set; }
    }
}
