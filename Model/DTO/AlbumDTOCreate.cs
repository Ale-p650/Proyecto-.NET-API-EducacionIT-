using Model.Entidades;
using Model.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTO
{
    public class AlbumDTOCreate
    {

        [Required]
        public string Nombre { get; set; }

        [Range(1500, 2024)]
        public int Año { get; set; }

        [Required]
        public string CoverURL { get; set; }


        public ICollection<Genero>? Generos { get; set; }

        [Required]
        public ICollection<CancionDTOCreateAlbum> Canciones { get; set; }

        [Required]
        public int ArtistaID { get; set; }
        public Artista? Artista { get; set; }
    }
}
