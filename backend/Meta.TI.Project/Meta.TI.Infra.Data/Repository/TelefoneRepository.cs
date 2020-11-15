using System;
using System.Collections.Generic;
using System.Linq;
using Meta.TI.Domain.Interfaces;
using Meta.TI.Domain.Models;
using Meta.TI.Infra.Data.Context;

namespace Meta.TI.Infra.Data.Repository
{
    public class TelefoneRepository : Repository<Telefone>, ITelefoneRepository
    {
        public TelefoneRepository(MetaTiContext context) : base(context)
        {
        }
        public Telefone ObterTelefone(int id)
        {
            return DbSet.FirstOrDefault(x => x.Id == id);
        }
        public List<Telefone> ObterTelefonesPorHemocentro(Guid idHemocentro)
        {
            return DbSet.Where(x => x.IdHemocentro == idHemocentro).ToList();
        }
    }
}
