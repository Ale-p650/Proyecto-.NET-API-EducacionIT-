using Microsoft.AspNetCore.Mvc;
using Model.Entidades;
using Repositorio.Interfaces;

namespace ProyectoIT.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaisController : Controller
    {
        #region ctor

        private readonly IPaisRepositorio _repositorio;

        public PaisController(IPaisRepositorio repositorio)
        {
            _repositorio = repositorio;
        }


        #endregion

        [HttpGet]
        public async Task<IActionResult> GetPaises()
        {
            var result=await this._repositorio.GetPaises();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPaises([FromRoute] int id)
        {
            var result = await this._repositorio.GetPaisByID(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CrearPais([FromQuery]string nombre)
        {
            Pais p = new Pais() { NombrePais = nombre };
            await _repositorio.CrearPais(p);

            //return CreatedAtRouteResult
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> BorrarPais([FromRoute] int id)
        {
            await _repositorio.RemovePais(id);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePais([FromBody] Pais p)
        {
            await _repositorio.UpdatePais(p.ID, p.NombrePais);
            return Ok();
        }
    }
}
