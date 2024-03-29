using System;
using System.Collections.Generic;
using System.Text;
using Meta.TI.Domain.Commands;
using Meta.TI.Domain.Interfaces;
using Meta.TI.Domain.Models;
using Meta.TI.Infra.Data.Context;

namespace Meta.TI.Infra.Data.Repository
{
    public class RecompensasRepository : Repository<Recompensas>, IRecompensasRepository
    {
        public RecompensasRepository(MetaTiContext context) : base(context)
        {
        }
    }
}
