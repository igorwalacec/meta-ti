using System;
using System.Collections.Generic;
using System.Text;
using Meta.TI.Domain.Interfaces;
using Meta.TI.Domain.Models;
using Meta.TI.Infra.Data.Context;

namespace Meta.TI.Infra.Data.Repository
{
    public class ResultadoAptidaoRepository : Repository<ResultadoAptidao>, IResultadoAptidaoRepository
    {
        public ResultadoAptidaoRepository(MetaTiContext context) : base(context)
        {
        }
    }
}
