using Domain.Models.TarefaNS;
using Domain.TarefaNS.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.TarefaNS.Interface
{
    public interface ITarefaService
    {
        public bool Adicionar(Tarefa tarefa);
        public bool Editar(Tarefa tarefa);
        public bool Deletar(int tarefaId);
        public List<Tarefa> Get(BuscarTarefaQuery query);
    }
}
