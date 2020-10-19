using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Meta.TI.Domain.Interfaces;
using Meta.TI.Domain.Models;
using Meta.TI.Infra.Data.Context;

namespace Meta.TI.Infra.Data.Repository
{
    public class HemocentroRepository : Repository<Hemocentro>, IHemocentroRepository
    {
        public HemocentroRepository(MetaTiContext context) : base(context)
        {

        }

        public List<Hemocentro> ObterTodosHemocentro()
        {
            return DbSet.ToList();
        }

        public Hemocentro ObterHemocentroPorId(Guid guid)
        {
            return DbSet.FirstOrDefault(x => x.Id == guid);
            //TODO: incluir expediente e demais informações para retorno
        }

        public bool VerificarExistenciaCNPJ(string cnpj)
        {
            return DbSet.Where(x => x.CNPJ.ToUpper() == cnpj.ToUpper()).Any();
        }
    }
}
