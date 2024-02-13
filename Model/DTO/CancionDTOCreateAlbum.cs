using Model.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTO
{
    public class CancionDTOCreateAlbum
    {
        

        [Required]
        public string Nombre { get; set; }
        public int OrdenAlbum { get; set; }
        public int Duracion { get; set; }

        
    }


}
