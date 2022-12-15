using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.AvaliacaoNS.Query
{
    public class BuscarAvaliacaoQuery
    {
        public int Id { get; set; }
        public int EntregaId { get; set; }
        public int AlunoId { get; set; }
    }
}
