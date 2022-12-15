using Domain.AtrasoNS.Query;
using Domain.Models.AtrasoNS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.AtrasoNS.Interface
{
    public interface IAtrasoRepository
    {
        public bool Adicionar(Atraso atraso);
        public bool Editar(Atraso atraso);
        public bool Delete(Atraso atraso);
        public List<Atraso> Get(BuscarAtrasoQuery query);
    }
}
