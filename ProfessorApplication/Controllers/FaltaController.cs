using Domain.FaltaNS.Interface;
using Domain.FaltaNS.Query;
using Domain.Models.FaltaNS;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProfessorApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FaltaController : ControllerBase
    {
        private readonly IFaltaService _faltaService;
        public FaltaController(IFaltaService faltaService)
        {
            _faltaService = faltaService;
        }

        [HttpGet]
        public IActionResult Get([FromQuery]BuscarFaltaQuery query)
        {
            return Ok(_faltaService.Get(query));
        }
        [Authorize]
        [HttpPost]
        public IActionResult Post([FromBody] Falta falta)
        {
            return Ok(_faltaService.Registrar(falta));
        }
        [Authorize]
        [HttpPut]
        public IActionResult Put([FromBody] Falta falta)
        {
            return Ok(_faltaService.Editar(falta));
        }
        [Authorize]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            return Ok(_faltaService.Delete(id));
        }
    }
}
