using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.AtrasoNS.Query
{
    public class BuscarAtrasoQuery
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public int AlunoId { get; set; }
    }
}
