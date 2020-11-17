using System;
using System.Collections.Generic;
using System.Linq;
using Meta.TI.Domain.Interfaces;
using Meta.TI.Domain.Models;
using Meta.TI.Infra.Data.Context;

namespace Meta.TI.Infra.Data.Repository
{
    public class ExpedienteRepository : Repository<Expediente>, IExpedienteRepository
    {
        public ExpedienteRepository(MetaTiContext context) : base(context)
        {
        }
        public Expediente ObterExpediente(Guid idHemocentro, int idDiaSemana)
        {
            return DbSet.FirstOrDefault(x => x.IdHemocentro == idHemocentro && x.IdDiaSemana == idDiaSemana);
        }
        public List<Expediente> ObterExpedientePorIdHemocentro(Guid idHemocentro)
        {
            return DbSet.Where(x => x.IdHemocentro == idHemocentro).ToList();
        }
    }
}
