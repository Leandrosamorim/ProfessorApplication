using Domain.Models.AlunoNS;
using Domain.Models.EntregaNS;
using Domain.ProfessorNS.Interface;
using Domain.ProfessorNS.Query;
using Domain.Queue.Interface;
using Domain.Queue.Service;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ProfessorNS.Service
{
    public class ProfessorService : IProfessorService
    {
        private readonly IProfessorRepository _professorRepository;
        private readonly IConfiguration _configuration;
        private readonly IQueueService _queueService;
        public ProfessorService(IProfessorRepository professorRepository, IQueueService queueService, IConfiguration configuration)
        {
            _professorRepository = professorRepository;
            _configuration = configuration;
            _queueService = queueService;
        }

        public async Task<List<Aluno>> BuscarAlunosPorProfessor(int professorId)
        {
            var turmaId = _professorRepository.BuscarTurmasDoProfessor(professorId);
            return await BuscarAlunosDoProfessor(turmaId);
        }

        public bool Deletar(int professorId)
        {
            var professor = new Professor() { Id = professorId };
            _professorRepository.Delete(professor);
            return true;
        }

        public bool Editar(Professor professor)
        {
            _professorRepository.Editar(professor);
            return true;
        }

        public List<Professor> Get(BuscaProfessorQuery query)
        {
            return _professorRepository.Get(query);
        }

        public Professor Logar(LogarProfessorCommand cmd)
        {
            return _professorRepository.Logar(cmd.UserName, cmd.Password);
        }

        public bool Registrar(Professor professor)
        {
            _professorRepository.Registrar(professor);
            return true;
        }

        public async Task<List<Aluno>> BuscarAlunosDoProfessor(List<int> turmaId)
        {
            var url = _configuration.GetSection("AlunoApplication").GetSection("Url").Value + "/Aluno?";
            foreach (var t in turmaId)
            {
                url = url + "TurmaId=" + t + "&";
            }
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(url.ToString());

                using (HttpResponseMessage response = await client.GetAsync(url, new CancellationToken()))
                {
                    var responseContent = response.Content.ReadAsStringAsync().Result;
                    response.EnsureSuccessStatusCode();
                    var alunos = JsonConvert.DeserializeObject<List<Aluno>>(responseContent);
                    return alunos;
                }
            }
        }

        public async void NotificarProfessor()
        {
            var entrega = _queueService.Consume();
            //todo
        }


    }
}
