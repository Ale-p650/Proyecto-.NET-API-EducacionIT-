using Microsoft.AspNetCore.Mvc;
using Model.Entidades;
using Repositorio.Interfaces;

namespace ProyectoIT.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GeneroController : Controller
    {
        #region ctor

        private readonly IGeneroRepositorio _repositorio;

        public GeneroController(IGeneroRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        #endregion

        [HttpGet]
        public async Task<IActionResult> GetGeneros()
        {
            var result = await _repositorio.GetGeneros();

            if (result == null || result.Count == 0)
            {
                return NotFound("No hay artistas para mostrar");
            }

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGeneroByID(int id)
        {
            var result = await _repositorio.GetGeneroByID(id);
            if (result == null)
            {
                return NotFound("No hay artistas para mostrar");
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CrearGenero([FromQuery]string nombre)
        {
            Genero g = new Genero() { NombreGenero = nombre };
            await _repositorio.CrearGenero(g);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> BorrarGenero(int id)
        {
            var result = await _repositorio.RemoveGenero(id);
            if (result) return Ok($"Se ha eliminado Genero con ID: {id}");
            else return BadRequest("No se ha podido eliminar el recurso solicitado");

        }

        [HttpPut]
        public async Task<IActionResult> UpdateGenero([FromBody] Genero g)
        {
            var x=await _repositorio.UpdateGenero(g.ID, g.NombreGenero);
            return Ok(x);
        }
    }
}
