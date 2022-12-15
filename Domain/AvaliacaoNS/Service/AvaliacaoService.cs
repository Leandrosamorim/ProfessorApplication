using Domain.AvaliacaoNS.Interface;
using Domain.AvaliacaoNS.Query;
using Domain.Models.AvaliacaoNS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.AvaliacaoNS.Service
{
    public class AvaliacaoService : IAvaliacaoService
    {
        private readonly IAvaliacaoRepository _avaliacaoRepository;

        public AvaliacaoService(IAvaliacaoRepository avaliacaoRepository)
        {
            _avaliacaoRepository = avaliacaoRepository;
        }

        public bool Deletar(int avaliacaoId)
        {
            var avaliacao = new Avaliacao() { Id= avaliacaoId };
            return _avaliacaoRepository.Deletar(avaliacao);
            
        }

        public bool Editar(Avaliacao avaliacao)
        {
            return _avaliacaoRepository.Editar(avaliacao);
        }

        public List<Avaliacao> Get(BuscarAvaliacaoQuery query)
        {
            return _avaliacaoRepository.Get(query);
        }

        public bool Registrar(Avaliacao avaliacao)
        {
            return _avaliacaoRepository.Registrar(avaliacao);
        }
    }
}
