using Domain.Models.TarefaNS;
using Domain.TarefaNS.Interface;
using Domain.TarefaNS.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.TarefaNS.Service
{
    public class TarefaService : ITarefaService
    {
        private readonly ITarefaRepository _tarefaRepository;

        public TarefaService(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }

        public bool Adicionar(Tarefa tarefa)
        {
            _tarefaRepository.Adicionar(tarefa);
            return true;
        }

        public bool Deletar(int tarefaId)
        {
            var tarefa = new Tarefa() { Id = tarefaId };
            _tarefaRepository.Deletar(tarefa);
            return true;
        }

        public bool Editar(Tarefa tarefa)
        {
            _tarefaRepository.Editar(tarefa);
            return true;
        }

        public List<Tarefa> Get(BuscarTarefaQuery query)
        {
            return _tarefaRepository.Buscar(query);
        }
    }
}
