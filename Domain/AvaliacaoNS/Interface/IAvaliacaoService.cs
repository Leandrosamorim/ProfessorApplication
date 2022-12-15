using Domain.AvaliacaoNS.Query;
using Domain.Models.AvaliacaoNS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.AvaliacaoNS.Interface
{
    public interface IAvaliacaoService
    {
        public bool Registrar(Avaliacao avaliacao);
        public bool Editar(Avaliacao avaliacao);
        public bool Deletar(int avaliacaoId);
        public List<Avaliacao> Get(BuscarAvaliacaoQuery query);
    }
}
