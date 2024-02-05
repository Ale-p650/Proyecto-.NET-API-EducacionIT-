using Model.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTO
{
    public class ArtistaDTOGetAlbum
    {

        #region ctor

        public ArtistaDTOGetAlbum(Artista artista)
        {
            this.ID = artista.ID;
            this.Nombre = artista.Nombre;
            this.Oyentes = artista.Oyentes;
            this.IsVerified = artista.IsVerified;
            this.PathFoto = artista.PathFoto;
            this.Descripcion = artista.Descripcion;
            this.PaisID = artista.PaisID;

        }

        #endregion



        [Required]
        public int ID { get; set; }

        [Required]
        public string Nombre { get; set; }
        public int Oyentes { get; set; }
        public bool IsVerified { get; set; }
        public string PathFoto { get; set; }
        public string Descripcion { get; set; }

        [Required]
        public int PaisID { get; set; }
        public PaisDTOGetAlbum Pais { get; set; }

        

        
    }
}
