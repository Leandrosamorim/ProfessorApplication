using Domain.Models.AlunoNS;
using Domain.ProfessorNS.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ProfessorNS.Interface
{
    public interface IProfessorRepository
    {
        public bool Registrar(Professor professor);
        public bool Editar(Professor professor);
        public bool Delete(Professor professor);
        public List<Professor> Get(BuscaProfessorQuery query);
        public Professor Logar(string userName, string password);
        public List<int> BuscarTurmasDoProfessor(int professorId);
    }
}
