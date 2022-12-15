using Data.Context;
using Domain.Models.TarefaNS;
using Domain.TarefaNS.Interface;
using Domain.TarefaNS.Query;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class TarefaRepository : ITarefaRepository
    {
        private readonly ProfessorContext _context;
        public TarefaRepository(ProfessorContext context)
        {
            _context = context;
        }

        [Authorize]
        public bool Adicionar(Tarefa tarefa)
        {
            _context.Tarefa.Add(tarefa);
            _context.SaveChanges();
            return true;
        }

        public List<Tarefa> Buscar(BuscarTarefaQuery query)
        {
            var tarefas = _context.Tarefa.Where(x => x.Id == query.Id || x.Name == query.Nome || x.TurmaId == query.TurmaId).Include(t => t.Entrega).Include(t => t.Entrega.Avaliacao).ToList();
            return tarefas;
        }

        [Authorize]
        public bool Deletar(Tarefa tarefa)
        {
            _context.Tarefa.Remove(tarefa);
            _context.SaveChanges();
            return true;
        }

        [Authorize]
        public bool Editar(Tarefa tarefa)
        {
            _context.Tarefa.Update(tarefa);
            _context.SaveChanges();
            return true;
        }
    }
}
