using Domain.Models.EntregaNS;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.AvaliacaoNS
{
    public class Avaliacao
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Nota { get; set; }
        public int EntregaId { get; set; }

    }
}
