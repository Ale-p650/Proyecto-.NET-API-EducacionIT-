using Microsoft.AspNetCore.Mvc;
using Model.Entidades;
using Repositorio.Interfaces;
using ProyectoIT.Filtros;

namespace ProyectoIT.Controllers
{
    [FiltroAccion]
    [ApiController]
    [Route("[controller]")]
    public class CancionController : Controller
    {
        #region ctor

        private readonly ICancionRepositorio _repositorio;

        public CancionController(ICancionRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        #endregion

        [HttpGet]
        public async Task<IActionResult> GetCanciones()
        {
            var result = await _repositorio.GetCanciones();
            if (result == null || result.Count == 0)
            {
                return NotFound("No hay Canciones para mostrar");
            }

            return Ok(result);
        }

        [HttpGet("{id}",Name ="GetCancionByID")]
        public async Task<IActionResult> GetCancionByID(int id)
        {
            var result = await _repositorio.GetCancionByID(id);
            if (result == null)
            {
                return NotFound("No hay Canciones para mostrar");
            }

            return Ok(result);
        }

        [HttpGet("album/{id}")]
        public async Task<IActionResult> GetCancionByAlbumID(int id)
        {
            var result = await _repositorio.GetCancionByAlbumID(id);
            if (result == null || result.Count == 0)
            {
                return NotFound("No hay Canciones para mostrar");
            }

            return Ok(result);
        }

        [HttpGet("artista/{id}")]
        public async Task<IActionResult> GetCancionByArtistaID(int id)
        {
            var result = await _repositorio.GetCancionByArtistaID(id);
            if (result == null || result.Count == 0)
            {
                return NotFound("No hay Canciones para mostrar");
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CrearCancion([FromBody] Cancion c)
        {
            
            var result = await _repositorio.CrearCancion(c);
            if (result)
            {
                //return CreatedAtRoute("GetByID", new {id=})
            }

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> BorrarCancion(int id)
        {
            var result = await _repositorio.RemoveCancion(id);
            if (result) return Ok($"Se ha eliminado la Cancion con ID: {id}");
            else return BadRequest("No se ha podido eliminar el recurso solicitado");

        }

        [HttpPut]
        public async Task<IActionResult> UpdateGenero([FromBody] Genero g)
        {
            throw new NotImplementedException();
        }
    }
}
