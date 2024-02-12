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

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAlbumByID(int id)
        {
            var result = await _repositorio.GetByIDAsync(id);
            return Ok(result);
        }

        [HttpGet("dto")]
        public async Task<IActionResult> GetAlbumDTO()
        {
            var select = await this._repositorio.GetDTOAllAsync();

            return Ok(select);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAlbum([FromBody]AlbumDTOCreate album)
        {
            var result = await _repositorio.CreateAsync(album);
            return Ok(result);
        }


    }
}
