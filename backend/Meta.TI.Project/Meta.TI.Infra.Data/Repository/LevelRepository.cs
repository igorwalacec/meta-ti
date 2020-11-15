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

        public int CalcularLevel(int countDoacao)
        {
            var primeiraDoacao = DbSet.Where(x => x.Ativo == true).First().QuantidadeDoacao;

            var retorno = DbSet.Where(x => x.QuantidadeDoacao >= primeiraDoacao
            && x.QuantidadeDoacao <= countDoacao
            && x.Ativo == true)
                .OrderByDescending(x => x.QuantidadeDoacao)
                .FirstOrDefault().Nivel;

            return retorno;
        }
    }
}
