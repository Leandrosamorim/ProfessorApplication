using Domain.Models.TarefaNS;
using Domain.TarefaNS.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.TarefaNS.Interface
{
    public interface ITarefaRepository
    {
        public bool Adicionar(Tarefa tarefa);
        public bool Editar(Tarefa tarefa);
        public List<Tarefa> Buscar(BuscarTarefaQuery query);
        public bool Deletar(Tarefa tarefa);
    }
}
