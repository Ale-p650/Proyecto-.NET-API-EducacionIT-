using Model.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTO
{
    public class PlaylistDTOCreate
    {

        public PlaylistDTOCreate()
        {
            this.Canciones = new List<Cancion>();
        }

        public PlaylistDTOCreate(Playlist p)
        {
            this.Canciones = p.Canciones;
            this.ID = p.ID;
            this.Nombre = p.Nombre;
            this.UsuarioID = p.UsuarioID;
        }

        public Playlist GetPlaylist()
        {
            Playlist p = new Playlist()
            {
                ID = this.ID,
                UsuarioID = this.ID,
                Nombre = this.Nombre,
                Descripcion = " ",
                NumeroTracks = 0,
                Duracion = 0,
                Likes = 0,
                Canciones = new List<Cancion>()
            };
            return p;
        }

        public int ID { get; set; }

        [Required]
        public int UsuarioID { get; set; }

        public string Nombre { get; set; }

        
        

        public ICollection<Cancion>? Canciones { get; set; }
    }
}
