using System;
using System.Collections.Generic;
using System.Linq;
using Meta.TI.Domain.Interfaces;
using Meta.TI.Domain.Models;
using Meta.TI.Infra.Data.Context;


namespace Meta.TI.Infra.Data.Repository
{
    public class EstoqueSanguineoRepository : Repository<EstoqueSanguineo>, IEstoqueSanguineoRepository
    {
        public EstoqueSanguineoRepository(MetaTiContext context) : base(context)
        {
        }
        public List<EstoqueSanguineo> ObterTodosEstoqueSanguineo(Guid idHemocentro)
        {
            return DbSet.Where(x => x.IdHemocentro == idHemocentro).ToList();
        }

        public EstoqueSanguineo ObterEstoqueSanquineoPorTipo(Guid idHemocentro, int idTipoSanguineo)
        {
            return DbSet.FirstOrDefault(x => x.IdHemocentro == idHemocentro && x.IdTipoSanguineo == idTipoSanguineo);
        }
    }
}
