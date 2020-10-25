using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Meta.TI.Domain.Interfaces;
using Meta.TI.Domain.Models;
using Meta.TI.Infra.Data.Context;

namespace Meta.TI.Infra.Data.Repository
{
    public class QuestoesAptidaoRepository : Repository<QuestoesAptidao>, IQuestoesAptidaoRepository
    {
        public QuestoesAptidaoRepository(MetaTiContext context) : base(context)
        {
        }
    }
}
