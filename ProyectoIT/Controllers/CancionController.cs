using Microsoft.AspNetCore.Mvc;
using Model.Entidades;
using Repositorio.Interfaces;

namespace ProyectoIT.Controllers
{
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
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCancionByID(int id)
        {
            var result = await _repositorio.GetCancionByID(id);
            return Ok(result);
        }

        [HttpGet("album/{id}")]
        public async Task<IActionResult> GetCancionByAlbumID(int id)
        {
            var result = await _repositorio.GetCancionByAlbumID(id);
            return Ok(result);
        }

        [HttpGet("artista/{id}")]
        public async Task<IActionResult> GetCancionByArtistaID(int id)
        {
            var result = await _repositorio.GetCancionByArtistaID(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CrearCancion([FromBody] Cancion c)
        {
            
            await _repositorio.CrearCancion(c);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> BorrarCancion(int id)
        {
            var result = await _repositorio.RemoveCancion(id);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateGenero([FromBody] Genero g)
        {
            throw new NotImplementedException();
        }
    }
}
