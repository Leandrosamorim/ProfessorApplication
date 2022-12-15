using Domain.AvaliacaoNS.Interface;
using Domain.AvaliacaoNS.Query;
using Domain.Models.AvaliacaoNS;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProfessorApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvaliacaoController : ControllerBase
    {
        private readonly IAvaliacaoService _avaliacaoService;
        public AvaliacaoController(IAvaliacaoService avaliacaoService)
        {
            _avaliacaoService = avaliacaoService;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] BuscarAvaliacaoQuery query) 
        {
            return Ok(_avaliacaoService.Get(query));
        }

        [Authorize]
        [HttpPost]
        public IActionResult Post([FromBody] Avaliacao avaliacao)
        {
            return Ok(_avaliacaoService.Registrar(avaliacao));
        }
        [Authorize]
        [HttpPut]
        public IActionResult Put([FromBody]Avaliacao avaliacao)
        {
            return Ok(_avaliacaoService.Editar(avaliacao));
        }
        [Authorize]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            return Ok(_avaliacaoService.Deletar(id));
        }

    }
}
