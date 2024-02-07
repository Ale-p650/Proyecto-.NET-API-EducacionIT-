using Model.DTO;
using Model.Entidades;
using System.ComponentModel.DataAnnotations;

namespace Repositorio.Interfaces
{
    public class ArtistaDTOGet
    {
        #region ctor

        public ArtistaDTOGet(Artista artista)
        {
            this.ID = artista.ID;
            this.Nombre = artista.Nombre;
            this.PathFoto = artista.PathFoto;
            this.PaisID = artista.PaisID;
            this.Albums = new List<AlbumDTOGet>();
            
        }

        #endregion



        [Required]
        public int ID { get; set; }

        [Required]
        public string Nombre { get; set; }
        public string PathFoto { get; set; }
        

        [Required]
        public int PaisID { get; set; }
        public PaisDTOGetAlbum Pais { get; set; }

        public List<AlbumDTOGet>? Albums { get; set; }
    }
}