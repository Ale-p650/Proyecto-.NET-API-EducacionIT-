using Model.DTO;
using Model.Entidades;
using Newtonsoft.Json;
using Repositorio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Clases_Servicio
{
    public class AlbumFileREPO : IAlbumRepositorio
    {
        #region ctor

        private readonly string _path;

        public AlbumFileREPO(string path)
        {
            _path = path;
        }

        #endregion

        public async Task<Album> CreateAsync(AlbumDTOCreate album)
        {
            using (StreamWriter sw = new StreamWriter(Path.Combine(this._path, "Albums.json") ))
            {
                string json = JsonConvert.SerializeObject(album);
                await sw.WriteLineAsync(json);


                return new Album();
            }
            
        }

        public Task<List<Album>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<string> GetByIDAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<AlbumDTOGet>> GetDTOAllAsync()
        {
            using (StreamReader sr = new StreamReader(Path.Combine(this._path, "Albums.json")))
            {
                string json = await sr.ReadToEndAsync();

                List<AlbumDTOGet> lista = JsonConvert.DeserializeObject<List<AlbumDTOGet>>(json);

                return lista;

            }
        }

        public Task<int> RemoveAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
