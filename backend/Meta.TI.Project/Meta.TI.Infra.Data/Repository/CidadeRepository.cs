using Meta.TI.Domain.Interfaces;
using Meta.TI.Domain.Models;
using Meta.TI.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Meta.TI.Infra.Data.Repository
{
    public class CidadeRepository : Repository<Cidade>, ICidadeRepository
    {
        public CidadeRepository(MetaTiContext context) : base(context){}
        public IQueryable<Cidade> ObterCidadesPorEstado(int idEstado)
        {
            return DbSet.Where(x => x.IdEstado == idEstado);
        }
    }
}
