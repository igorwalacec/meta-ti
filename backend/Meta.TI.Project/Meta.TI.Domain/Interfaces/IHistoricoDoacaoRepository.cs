using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Meta.TI.Domain.Commands;
using Meta.TI.Domain.Models;

namespace Meta.TI.Domain.Interfaces
{
    public interface IHistoricoDoacaoRepository : IRepository<HistoricoDoacao>
    {
        public IQueryable<HistoricoDoacao> ObterDoacaoPorId(Guid idUsuario);
    }
}
