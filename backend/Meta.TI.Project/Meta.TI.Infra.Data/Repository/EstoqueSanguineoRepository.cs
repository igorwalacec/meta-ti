using System;
using System.Collections.Generic;
using System.Linq;
using Meta.TI.Domain.Interfaces;
using Meta.TI.Domain.Models;
using Meta.TI.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

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

        public List<EstoqueSanguineo> ExtracaoEstoqueSanguineoParaNotificacoes(int idCidade, int? idTipoSanguineo)
        {
            return DbSet.Where(x => x.QuantidadeBolsas < x.QuantidadeMinimaBolsas
                                    && x.Hemocentro.Endereco.IdCidade == idCidade
                                    && (idTipoSanguineo != null ? x.IdTipoSanguineo == idTipoSanguineo : 0 == 0))
               .Include(y => y.Hemocentro)
               .Include(z => z.TipoSanguineo)
               .ToList();
        }
    }
}
