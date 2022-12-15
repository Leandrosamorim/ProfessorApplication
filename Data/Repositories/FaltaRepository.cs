using Data.Context;
using Domain.FaltaNS.Interface;
using Domain.FaltaNS.Query;
using Domain.Models.FaltaNS;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class FaltaRepository : IFaltaRepository
    {
        private readonly ProfessorContext _context;
        public FaltaRepository(ProfessorContext context)
        {
            _context = context;
        }

        public bool Delete(Falta falta)
        {
            _context.Falta.Remove(falta);
            _context.SaveChanges();
            return true;
        }

        public bool Editar(Falta falta)
        {
            _context.Falta.Update(falta);
            _context.SaveChanges();
            return true;
        }

        public List<Falta> Get(BuscarFaltaQuery query)
        {
            return _context.Falta.Where(x =>
            x.Id == query.Id || x.Data == query.Data || x.AlunoId == query.AlunoId).Include(x => x.Justificativa).ToList();
        }

        public bool Registrar(Falta falta)
        {
            _context.Falta.Add(falta);
            _context.SaveChanges();
            return true;
        }
    }
}
