using Domain.FaltaNS.Query;
using Domain.Models.FaltaNS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.FaltaNS.Interface
{
    public interface IFaltaService
    {
        public bool Registrar(Falta falta);
        public bool Editar(Falta falta);
        public bool Delete(int faltaId);
        public List<Falta> Get(BuscarFaltaQuery query);
    }
}
