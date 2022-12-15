using Domain.AtrasoNS.Query;
using Domain.Models.AtrasoNS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.AtrasoNS.Interface
{
    public interface IAtrasoService
    {
        public bool Adicionar(Atraso atraso);
        public bool Editar(Atraso atraso);
        public bool Delete(int atrasoId);
        public List<Atraso> Get(BuscarAtrasoQuery query);
    }
}
