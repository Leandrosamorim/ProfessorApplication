using Domain.Models.AtrasoNS;
using Domain.Models.AvaliacaoNS;
using Domain.Models.FaltaNS;
using Domain.Models.TarefaNS;
using Domain.ProfessorNS;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context
{
    public class ProfessorContext : DbContext
    {
        public ProfessorContext(DbContextOptions<ProfessorContext> options) : base(options)
        {

        }
        public virtual DbSet<Professor> Professor { get; set; }
        public virtual DbSet<Tarefa> Tarefa { get; set; }
        public virtual DbSet<Atraso> Atraso { get; set; }
        public virtual DbSet<Falta> Falta { get; set; }
        public virtual DbSet<Avaliacao> Avaliacao { get; set; }
    }
}
