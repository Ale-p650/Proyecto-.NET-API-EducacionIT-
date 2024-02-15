using Microsoft.AspNetCore.Mvc;
using Model.DTO;
using Model.Entidades;
using Repositorio.Interfaces;

namespace ProyectoIT.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlbumController : Controller
    {
        #region ctor

        private readonly IAlbumRepositorio _repositorio;

        public AlbumController(IAlbumRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        #endregion



        [HttpGet]
        public async Task<IActionResult> GetAlbum()
        {
            var result= await this._repositorio.GetAllAsync();

            if (result == null || result.Count==0)
            {
                return NotFound("No hay Albums para mostrar");
            }

            return Ok(result);
        }

        [HttpGet("{id}",Name ="GetByID")]
        public async Task<IActionResult> GetAlbumByID(int id)
        {
            var result = await _repositorio.GetByIDAsync(id);

            //if (result == null)
            //{
            //    return NotFound("No se ha encontrado el Album solicitado");
            //}

            return Content(result);
        }

        [HttpGet("dto")]
        public async Task<IActionResult> GetAlbumDTO()
        {
            var result = await this._repositorio.GetDTOAllAsync();

            if (result == null)
            {
                return NotFound("No se ha encontrado el Album solicitado");
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAlbum([FromBody]AlbumDTOCreate album)
        {
            var result = await _repositorio.CreateAsync(album);
            return Ok();
        }


    }
}
