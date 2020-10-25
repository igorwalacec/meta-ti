using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Meta.TI.Domain.Interfaces;
using Meta.TI.Domain.Models;
using Meta.TI.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Meta.TI.Infra.Data.Repository
{
    public class HistoricoAptidaoRepository : Repository<HistoricoAptidao>, IHistoricoAptidaoRepository
    {
        public HistoricoAptidaoRepository(MetaTiContext context) : base(context)
        {
        }


        public HistoricoAptidao CalcularDayOff(Guid usuarioId)
        {
            var retorno = DbSet.Where(x => x.Usuario_Id == usuarioId)
                .Include(z => z.ResultadoAptidao.RespostasAptidao)
                .Include(y => y.ResultadoAptidao)
                .OrderByDescending(y => y.ResultadoAptidao.DataProximaDoacao).FirstOrDefault();                

            return retorno;     
        }
    }
}
