using Model.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTO
{
    public class PaisDTOGetAlbum
    {
        #region ctor

        public PaisDTOGetAlbum(Pais pais)
        {
            this.ID = pais.ID;
            this.NombrePais = pais.NombrePais;
        }

        #endregion

        public int ID { get; set; }

        [Required]
        public string NombrePais { get; set; }
    }
}
