using Domain.Models.AlunoNS;
using Domain.ProfessorNS;
using Domain.ProfessorNS.Interface;
using Domain.ProfessorNS.Query;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace ProfessorApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        private readonly IProfessorService _professorService;
        private readonly IConfiguration _configuration;
        public ProfessorController(IProfessorService professorService, IConfiguration configuration)
        {
            _professorService = professorService;
            _configuration = configuration;
        }
        [HttpGet]
        public IActionResult Get([FromQuery]BuscaProfessorQuery query) 
        {
            return Ok(_professorService.Get(query));
        }

        [HttpPost]
        public IActionResult Post([FromBody] Professor professor)
        {
            return Ok(_professorService.Registrar(professor));
        }

        [HttpPut]
        public IActionResult Put([FromBody] Professor professor)
        {
            return Ok(_professorService.Editar(professor));
        }
        [HttpDelete]
        public IActionResult Delete(int professorId)
        {
            return Ok(_professorService.Deletar(professorId));
        }

        [Authorize]
        [HttpGet]
        [Route("/aluno")]
        public async Task<List<Aluno>> GetAluno()
        {
            var professorId = Int32.Parse(User.FindFirst("id").Value);
            return await _professorService.BuscarAlunosPorProfessor(professorId);
        }
    }
}
