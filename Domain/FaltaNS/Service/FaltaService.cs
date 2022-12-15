using Domain.FaltaNS.Interface;
using Domain.FaltaNS.Query;
using Domain.Models.FaltaNS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.FaltaNS.Service
{
    public class FaltaService : IFaltaService
    {
        private readonly IFaltaRepository _faltaRepository;
        public FaltaService(IFaltaRepository faltaRepository)
        {
            _faltaRepository= faltaRepository;
        }

        public bool Delete(int faltaId)
        {
            var falta = new Falta() { Id = faltaId};
            _faltaRepository.Delete(falta);
            return true;
        }

        public bool Editar(Falta falta)
        {
            _faltaRepository.Editar(falta);
            return true;
        }

        public List<Falta> Get(BuscarFaltaQuery query)
        {
            return _faltaRepository.Get(query);
        }

        public bool Registrar(Falta falta)
        {
            _faltaRepository.Registrar(falta);
            return true;
        }
    }
}
