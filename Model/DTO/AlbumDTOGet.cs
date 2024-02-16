using Microsoft.EntityFrameworkCore.Query.Internal;
using Model.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTO
{
    public class AlbumDTOGet
    {

        #region ctor

        public AlbumDTOGet()
        {
            
        }

        public AlbumDTOGet(Album album)
        {
            this.ID = album.ID;
            this.TipoDisco = album.TipoDisco;
            this.Nombre = album.Nombre;
            this.Año = album.Año;
            this.NumeroTracks = album.NumeroTracks;
            this.Duracion = album.Duracion;
            
            this.ArtistaID = album.ArtistaID;
            
        }

        #endregion


        public int ID { get; set; }
        public Tipo? TipoDisco { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Range(1500,2024)]
        public int Año { get; set; }

        public int NumeroTracks { get; set; }

        public int Duracion { get; set; }

        



        [Required]
        public int ArtistaID { get; set; }
        public ArtistaDTOGetAlbum Artista { get; set; }

        
    }
}
