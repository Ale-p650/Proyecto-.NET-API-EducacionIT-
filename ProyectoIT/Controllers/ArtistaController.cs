using Microsoft.AspNetCore.Mvc;
using Model.Entidades;
using Repositorio.Interfaces;

namespace ProyectoIT.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArtistaController : Controller
    {
        #region ctor

        private readonly IArtistaRepositorio _repositorio;

        public ArtistaController(IArtistaRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        #endregion

        [HttpGet]
        public async Task<IActionResult> GetArtistas()
        {
            var result = await _repositorio.GetAllAsync();
            if (result == null|| result.Count==0)
            {
                return NotFound("No hay artistas para mostrar");
            }

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID(int id)
        {
            var result = await _repositorio.GetByIDAsync(id);

            if (result == null)
            {
                return NotFound("No se ha encontrado el Artista solicitado");
            }

            return Ok(result);
        }

        [HttpGet("pais/{id}")]
        public async Task<IActionResult> GetArtistaByPaisID(int id)
        {
            var result = await _repositorio.GetByPais(id);
            if (result == null)
            {
                return NotFound("No se ha encontrado el Artista solicitado");
            }

            return Ok(result);
        }

        [HttpGet("dto")]
        public async Task<IActionResult> GetDTO()
        {
            var result = await _repositorio.GetDTOAllAsync();
            if (result == null)
            {
                return NotFound("No se ha encontrado el Artista solicitado");
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CrearArtista([FromBody] Artista ar)
        {

            var result= await _repositorio.CreateAsync(ar);
            if (result) return Ok($"Se ha creado Artista:  {ar.Nombre}");
            else return BadRequest("No se ha podido cargar el Artista");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> BorrarArtista(int id)
        {
            var result = await _repositorio.RemoveAsync(id);

            if (result) return Ok($"Se ha eliminado Artista con ID: {id}");
            else return BadRequest("No se ha podido eliminar el recurso solicitado");
            
        }

        
    }
}
