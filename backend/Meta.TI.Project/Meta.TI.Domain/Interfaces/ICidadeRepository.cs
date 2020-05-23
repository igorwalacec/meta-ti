using Meta.TI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Meta.TI.Domain.Interfaces
{
    public interface ICidadeRepository : IRepository<Cidade>
    {
        IQueryable<Cidade> ObterCidadesPorEstado(int idEstado);
    }
}
