using Domain.Models.AtrasoNS;
using Domain.Models.EntregaNS;
using Domain.Models.FaltaNS;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.AlunoNS
{
    public class Aluno
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nome { get; set; }
        [ForeignKey("Turma")]
        public int TurmaId { get; set; }
        public List<Falta>? Faltas { get; set; }
        public List<Atraso>? Atrasos { get; set; }
        public List<Entrega>? Entregas { get; set; }
    }
}
