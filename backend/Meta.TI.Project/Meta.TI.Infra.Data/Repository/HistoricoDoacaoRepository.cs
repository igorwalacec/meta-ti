using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Meta.TI.Domain.Commands;
using Meta.TI.Domain.Interfaces;
using Meta.TI.Domain.Models;
using Meta.TI.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Meta.TI.Infra.Data.Repository
{
    public class HistoricoDoacaoRepository : Repository<HistoricoDoacao>, IHistoricoDoacaoRepository
    {
        public HistoricoDoacaoRepository(MetaTiContext context) : base(context)
        {
        }

        public IQueryable<HistoricoDoacao> ObterDoacaoPorId(Guid idUsuario)
        {
            return DbSet.Where(x => x.IdUsuario == idUsuario)
                .Include(y => y.Hemocentro);
        }
    }
}
