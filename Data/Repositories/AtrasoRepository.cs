using Data.Context;
using Domain.AtrasoNS.Interface;
using Domain.AtrasoNS.Query;
using Domain.Models.AtrasoNS;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class AtrasoRepository : IAtrasoRepository
    {
        private readonly ProfessorContext _context;
        public AtrasoRepository(ProfessorContext context)
        {
            _context = context;
        }

        public bool Adicionar(Atraso atraso)
        {
            _context.Atraso.Add(atraso);
            _context.SaveChanges();
            return true;
        }

        public bool Delete(Atraso atraso)
        {
            _context.Atraso.Remove(atraso);
            _context.SaveChanges();
            return true;
        }

        public bool Editar(Atraso atraso)
        {
            _context.Atraso.Update(atraso);
            _context.SaveChanges();
            return true;
        }

        public List<Atraso> Get(BuscarAtrasoQuery query)
        {
            var atrasos = _context.Atraso.Where(x => x.Id == query.Id || x.AlunoId == query.AlunoId || x.Data == query.Data).Include(a => a.Justificativa).ToList();
            return atrasos;
        }
    }
}
