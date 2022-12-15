using Domain.AtrasoNS.Interface;
using Domain.AtrasoNS.Query;
using Domain.Models.AtrasoNS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.AtrasoNS.Service
{
    public class AtrasoService : IAtrasoService
    {
        private readonly IAtrasoRepository _atrasoRepository;

        public AtrasoService(IAtrasoRepository atrasoRepository)
        {
            _atrasoRepository = atrasoRepository;
        }

        public bool Adicionar(Atraso atraso)
        {
            _atrasoRepository.Adicionar(atraso);
            return true;
        }

        public bool Delete(int atrasoId)
        {
            var atraso = new Atraso() {Id = atrasoId};
            _atrasoRepository.Delete(atraso);
            return true;
        }

        public bool Editar(Atraso atraso)
        {
            _atrasoRepository.Editar(atraso);
            return true;
        }

        public List<Atraso> Get(BuscarAtrasoQuery query)
        {
            return _atrasoRepository.Get(query);
        }
    }
}
