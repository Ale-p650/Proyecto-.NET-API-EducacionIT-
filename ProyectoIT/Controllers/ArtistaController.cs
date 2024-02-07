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
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID(int id)
        {
            var result = await _repositorio.GetByIDAsync(id);
            return Ok(result);
        }

        [HttpGet("pais/{id}")]
        public async Task<IActionResult> GetCancionByAlbumID(int id)
        {
            var result = await _repositorio.GetByPais(id);
            return Ok(result);
        }

        [HttpGet("dto")]
        public async Task<IActionResult> GetDTO()
        {
            var result = await _repositorio.GetDTOAllAsync();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CrearArtista([FromBody] Artista ar)
        {

            await _repositorio.CreateAsync(ar);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> BorrarArtista(int id)
        {
            var result = await _repositorio.RemoveAsync(id);
            return Ok(result);
        }

        
    }
}
