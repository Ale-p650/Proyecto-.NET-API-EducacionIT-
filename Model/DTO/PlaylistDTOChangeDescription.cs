using Model.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTO
{
    public class PlaylistDTOChangeDescription
    {
        public int ID { get; set; }

        
        public string? Descripcion { get; set; }
        
    }
}
