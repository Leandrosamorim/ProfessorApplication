using Domain.AtrasoNS.Interface;
using Domain.AtrasoNS.Query;
using Domain.Models.AtrasoNS;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProfessorApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtrasoController : ControllerBase
    {
        private readonly IAtrasoService _atrasoService;

        public AtrasoController(IAtrasoService atrasoService)
        {
            _atrasoService = atrasoService;
        }

        [Authorize]
        [HttpGet]
        public List<Atraso> Get([FromQuery]BuscarAtrasoQuery query) 
        {
            return _atrasoService.Get(query);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Post([FromBody] Atraso atraso) 
        {
            return Ok(_atrasoService.Adicionar(atraso));
        }

        [Authorize]
        [HttpPut]
        public IActionResult Put([FromBody] Atraso atraso)
        {
            return Ok(_atrasoService.Editar(atraso));
        }

        [Authorize]
        [HttpDelete]
        public IActionResult Delete(int atrasoId)
        {
            return Ok(_atrasoService.Delete(atrasoId));
        }
    }
}
