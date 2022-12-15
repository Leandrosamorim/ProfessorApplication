using Domain.Models.TarefaNS;
using Domain.TarefaNS.Interface;
using Domain.TarefaNS.Query;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProfessorApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        private readonly ITarefaService _tarefaService;
        public TarefaController(ITarefaService tarefaService)
        {
            _tarefaService = tarefaService;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] BuscarTarefaQuery query) {
            return Ok(_tarefaService.Get(query));
        }

        [Authorize]
        [HttpPost]
        public IActionResult Post([FromBody] Tarefa tarefa)
        {
            return Ok(_tarefaService.Adicionar(tarefa));
        }

        [Authorize]
        [HttpPut]
        public IActionResult Put([FromBody] Tarefa tarefa)
        {
            return Ok(_tarefaService.Editar(tarefa));
        }
        [Authorize]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            return Ok(_tarefaService.Deletar(id));
        }
    }
}
