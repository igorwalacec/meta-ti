using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Meta.TI.Domain.Models;

namespace Meta.TI.Domain.Interfaces
{
    public interface IHistoricoAptidaoRepository : IRepository<HistoricoAptidao>
    {
        public HistoricoAptidao CalcularDayOff(Guid usuarioId);

    }
}
