using Domain.Models.EntregaNS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Queue.Interface
{
    public interface IQueueService
    {
        public Entrega Consume();
    }
}
