using Domain.FaltaNS.Query;
using Domain.Models.FaltaNS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.FaltaNS.Interface
{
    public interface IFaltaRepository
    {
        public bool Registrar(Falta falta);
        public bool Editar (Falta falta);
        public bool Delete (Falta falta);
        public List<Falta> Get(BuscarFaltaQuery query);
    }
}
