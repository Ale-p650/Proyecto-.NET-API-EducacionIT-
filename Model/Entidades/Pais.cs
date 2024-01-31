using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entidades
{
    public class Pais
    {
        public int ID { get; set; }
        public string NombrePais { get; set; }


        public IEnumerable<Album>? Albums { get; set; }
        public IEnumerable<Artista>? Artistas { get; set; }
    }
}
