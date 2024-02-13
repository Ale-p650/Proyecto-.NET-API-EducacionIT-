using Microsoft.AspNetCore.Mvc;
using Model.DTO;
using Repositorio.Interfaces;

namespace ProyectoIT.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlaylistController : Controller
    {
        #region ctor

        private readonly IPlaylistRepositorio _repositorio;

        public PlaylistController(IPlaylistRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        #endregion


        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlaylist(int id, [FromQuery]bool like)
        {
            var result = await _repositorio.GetPlaylist(id,like);
            return Ok(result);
        }

        [HttpPost("agregar/{idCancion}/{idPlaylist}")]
        public async Task<IActionResult> AgregarCancion(int idCancion,int idPlaylist)
        {
            var result =await _repositorio.AgregarCancion(idCancion, idPlaylist);
            return Ok("Cancion agregada :  "+result);
        }

        [HttpPost("borrar/{idCancion}/{idPlaylist}")]
        public async Task<IActionResult> BorrarCancion( int idCancion, int idPlaylist)
        {
            var result = await _repositorio.BorrarCancion(idCancion, idPlaylist);
            return Ok("Cancion borrada :  "+result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> BorrarPlaylist(int id)
        {
            var result = await _repositorio.BorrarPlaylist(id);
            if (result) return Ok($"Se ha eliminado Playlist con ID: {id}");
            else return BadRequest("No se ha podido eliminar el recurso solicitado");

        }

        [HttpPatch("nombre")]
        public async Task<IActionResult> CambiarNombre([FromBody]PlaylistDTOChangeName dto)
        {
            var result = await _repositorio.CambiarNombrePlaylist(dto.ID, dto.Nombre);
            return Ok(result);
        }

        [HttpPatch("descripcion")]
        public async Task<IActionResult> CambiarDescripcion([FromBody] PlaylistDTOChangeDescription dto)
        {
            var result = await _repositorio.CambiarDescripcionPlaylist(dto.ID, dto.Descripcion);
            return Ok(result);
        }

        [HttpPost]

        public async Task<IActionResult> CrearPlayList([FromBody] PlaylistDTOCreate dto)
        {
            await _repositorio.CrearPlaylist(dto);
            return Ok();
        }
    }
}
