using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entidades
{
    public class Genero
    {
        public int ID { get; set; }
        public string NombreGenero { get; set; }

        public IEnumerable<Album>? Albums { get; set; }
    }
}
