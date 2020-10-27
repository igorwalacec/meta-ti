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
    public class HemocentroRepository : Repository<Hemocentro>, IHemocentroRepository
    {
        public HemocentroRepository(MetaTiContext context) : base(context)
        {

        }

        public List<Hemocentro> ObterTodosHemocentro()
        {
            return DbSet.Where(x => x.Ativo == true).ToList();
        }

        public Hemocentro ObterHemocentroPorId(Guid guid)
        {
            return DbSet.Where(x => x.Id == guid)
                .Include(w => w.EstoquesSanguineos)
                .Include(y => y.Endereco)
                .Include(z => z.Expedientes)
                .Include(t => t.Telefones)
                .FirstOrDefault();
        }

        public bool VerificarExistenciaCNPJ(string cnpj)
        {
            return DbSet.Where(x => x.CNPJ.ToUpper() == cnpj.ToUpper()).Any();
        }
    }
}
