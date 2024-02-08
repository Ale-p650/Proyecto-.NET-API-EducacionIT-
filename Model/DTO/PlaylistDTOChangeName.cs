using Model.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTO
{
    public class PlaylistDTOChangeName
    {
        public int ID { get; set; }

        [Required]
        public string Nombre { get; set; }
        
        
    }
}
