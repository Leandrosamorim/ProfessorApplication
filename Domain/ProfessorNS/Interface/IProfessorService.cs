using Domain.Models.AlunoNS;
using Domain.ProfessorNS.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ProfessorNS.Interface
{
    public interface IProfessorService
    {
        public bool Registrar(Professor professor);
        public bool Editar(Professor professor);
        public bool Deletar(int professorId);
        public List<Professor> Get(BuscaProfessorQuery query);
        public Professor Logar(LogarProfessorCommand cmd);
        public Task<List<Aluno>> BuscarAlunosPorProfessor (int professorId);
    }
}
