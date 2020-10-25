using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Meta.TI.Domain.Interfaces;
using Meta.TI.Domain.Models;
using Meta.TI.Infra.Data.Context;

namespace Meta.TI.Infra.Data.Repository
{
    public class StatusDoacaoRepository : Repository<StatusDoacao>, IStatusDoacaoRepository
    {
        public StatusDoacaoRepository(MetaTiContext context) : base(context)
        {
        }

        public string BuscarStatus(int idStatus)
        {
            var retorno = DbSet.Where(x => x.IdStatus == idStatus).FirstOrDefault().Descricao;

            return retorno;
        }
    }
}
