using Microsoft.AspNetCore.Mvc;
using Model.DTO;
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
            var select= await this._repositorio.GetAllAsync();

            return Ok(select);
        }

        [HttpGet("dto")]
        public async Task<IActionResult> GetAlbumDTO()
        {
            var select = await this._repositorio.GetDTOAllAsync();

            return Ok(select);
        }
    }
}
