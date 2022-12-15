using Domain.Models.AvaliacaoNS;
using Domain.Models.TarefaNS;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.EntregaNS
{
    public class Entrega
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime DataEntrega { get; set; }
        public Uri BlobUrl { get; set; }
        public Avaliacao? Avaliacao { get; set; }
        [ForeignKey("Tarefa")]
        public int TarefaId { get; set; }
        [ForeignKey("Alunos")]
        public int AlunoId { get; set; }
    }

    public static class EntregaFactory
    {
        public static Entrega CriarEntrega(Uri blobUrl, int tarefaId, int alunoId)
        {
            return new Entrega()
            {
                BlobUrl = blobUrl,
                TarefaId = tarefaId,
                DataEntrega = DateTime.UtcNow,
                AlunoId = alunoId
            };
        }
    }
}
