using Data.Context;
using Domain.Models.AlunoNS;
using Domain.ProfessorNS;
using Domain.ProfessorNS.Interface;
using Domain.ProfessorNS.Query;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class ProfessorRepository : IProfessorRepository
    {
        private readonly ProfessorContext _context;
        public ProfessorRepository(ProfessorContext context)
        {
            _context = context;
        }

        [Authorize]
        public bool Delete(Professor professor)
        {
            try
            {
                _context.Professor.Remove(professor);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [Authorize]
        public bool Editar(Professor professor)
        {
            try
            {
                _context.Professor.Update(professor);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<Professor> Get(BuscaProfessorQuery query)
        {
            return _context.Professor.Where(x => x.Id == query.Id || x.Nome == query.Nome).ToList();
        }

        public bool Registrar(Professor professor)
        {
            try
            {
                _context.Professor.Add(professor);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public Professor? Logar(string userName, string password)
        {
            return _context.Professor.FirstOrDefault(u => u.UserName == userName && u.Password == password);
        }

        public List<int> BuscarTurmasDoProfessor(int professorId)
        {
            SqlParameter param = new SqlParameter("professorId", professorId);
            var query = _context.Database.SqlQueryRaw<int>("SELECT Id FROM Turma WHERE ProfessorId = @professorId", param).ToList();
            List<int> result = query.ToList();
            return result;
        }

    }
}
