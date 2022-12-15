using Data.Context;
using Domain.AvaliacaoNS.Interface;
using Domain.AvaliacaoNS.Query;
using Domain.Models.AvaliacaoNS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class AvaliacaoRepository : IAvaliacaoRepository
    {
        private readonly ProfessorContext _context;

        public AvaliacaoRepository(ProfessorContext context)
        {
            _context = context;
        }

        public bool Deletar(Avaliacao avaliacao)
        {
            _context.Remove(avaliacao);
            _context.SaveChanges();
            return true;
        }

        public bool Editar(Avaliacao avaliacao)
        {
            _context.Avaliacao.Update(avaliacao);
            _context.SaveChanges();
            return true;
        }

        public List<Avaliacao> Get(BuscarAvaliacaoQuery query)
        {
            var data = (from av in _context.Avaliacao
                           join ta in _context.Tarefa
                           on av.EntregaId equals ta.Entrega.Id
                           where av.Id == query.Id || av.EntregaId == query.EntregaId || ta.Entrega.AlunoId == query.AlunoId
                           select av).ToList();
            return data;
        }

        public bool Registrar(Avaliacao avaliacao)
        {
            _context.Avaliacao.Add(avaliacao);
            _context.SaveChanges();
            return true;
        }
    }
}
