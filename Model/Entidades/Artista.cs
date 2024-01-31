using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entidades
{
    public class Artista
    {
        public int ID { get; set; }
        public string  Nombre { get; set; }
        public int Oyentes { get; set; }
        public bool IsVerified { get; set; }
        public string PathFoto { get; set; }
        public string Descripcion { get; set; }

        public int PaisID { get; set; }
        public Pais? Pais { get; set; }

        public IEnumerable<Album>? Albums { get; set; }

        public IEnumerable<Cancion>? Canciones { get; set; }



    }
}
