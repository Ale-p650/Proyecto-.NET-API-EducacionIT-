using Model.Entidades;
using Model.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

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


        public ICollection<GeneroDTOCreateAlbum> Generos { get; set; }

        [Required]
        public ICollection<CancionDTOCreateAlbum> Canciones { get; set; }

        [Required]
        public int ArtistaID { get; set; }
        




        public int GetDuracionTotal()
        {
            int cont = 0;
            foreach (CancionDTOCreateAlbum c in this.Canciones)
            {
                cont += c.Duracion;
            }
            return cont;
        }

        public int SetTipo()
        {
            if (this.Canciones.ToArray().Length == 1)
            {
                return 2;
            }
            else if (this.Canciones.ToArray().Length > 1 && this.Canciones.ToArray().Length < 6)
            {
                return 1;
            }
            else return 0;
        }


        public async Task<byte[]> CoverDownload(string URL)
        {

            using (HttpClient client = new HttpClient())
            {
                return await client.GetByteArrayAsync(URL);
            }

        }

        public ICollection<Cancion> CastCanciones(int artistaID, int albumID)
        {
            ICollection<Cancion> canciones = new List<Cancion>();


            foreach (var c in this.Canciones)
            {
                Cancion cancion = new Cancion();
                cancion.ArtistaID = artistaID;
                cancion.Nombre = c.Nombre;
                cancion.OrdenAlbum = c.OrdenAlbum;
                cancion.Reproducciones = 0;
                cancion.Duracion = c.Duracion;
                cancion.AlbumID = albumID;

                canciones.Add(cancion);
            }

            return canciones;
        }

        public ICollection<Genero> CastGeneros()
        {
            ICollection<Genero> generos = new List<Genero>();


            foreach (var g in this.Generos)
            {
                Genero genero = new Genero();
                
                genero.NombreGenero = g.nombreGenero;
                genero.Albums = null;

                generos.Add(genero);
            }

            return generos;
        }

    }
}
