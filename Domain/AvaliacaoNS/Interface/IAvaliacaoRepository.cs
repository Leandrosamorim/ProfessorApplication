using Domain.AvaliacaoNS.Query;
using Domain.Models.AvaliacaoNS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.AvaliacaoNS.Interface
{
    public interface IAvaliacaoRepository
    {
        public bool Registrar(Avaliacao avaliacao);
        public bool Editar (Avaliacao avaliacao);
        public bool Deletar(Avaliacao avaliacao);
        public List<Avaliacao> Get(BuscarAvaliacaoQuery query);
    }
}
