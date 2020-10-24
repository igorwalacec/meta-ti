using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Meta.TI.Domain.Commands;
using Meta.TI.Domain.Interfaces;
using Meta.TI.Domain.Models;
using Meta.TI.Infra.Data.Context;

namespace Meta.TI.Infra.Data.Repository
{
    public class LevelRepository : Repository<Level>, ILevelRepository
    {
        public LevelRepository(MetaTiContext context) : base(context)
        {
        }
    }
}
