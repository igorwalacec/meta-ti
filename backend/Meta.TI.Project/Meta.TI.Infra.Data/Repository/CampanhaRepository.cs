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
    public class CampanhaRepository : Repository<Campanha>, ICampanhaRepository
    {
        public CampanhaRepository(MetaTiContext context) : base(context)
        {
        }

        public List<Campanha> ObterTodasCampanhas(DateTime dataAtual)
        {
            return DbSet.Where(x => (x.DataAlteracao == null ? x.DataCriacao : x.DataAlteracao) >= dataAtual.AddDays(-90))
                .Include(y => y.Hemocentro)
                .OrderByDescending(x => x.DataAlteracao == null ? x.DataCriacao : x.DataAlteracao)
                .ToList();
        }

        public List<Campanha> ObterCampanhaPorHemocentro(DateTime dataAtual, Guid idHemocentro)
        {
            return DbSet.Where(x => (x.DataAlteracao == null ? x.DataCriacao : x.DataAlteracao) >= dataAtual.AddDays(-90) && x.IdHemocentro == idHemocentro)
               .Include(y => y.Hemocentro)
               .OrderByDescending(x => x.DataAlteracao == null ? x.DataCriacao : x.DataAlteracao)
               .ToList();
        }

        public Campanha ObterCampanhaPorId(int id)
        {
            return DbSet.FirstOrDefault(x => x.Id == id);
        }

        public Campanha ObterCampanhaCriada(Guid idHemocentro)
        {
            return DbSet.Where(x => x.IdHemocentro == idHemocentro).OrderByDescending(x => x.DataCriacao).FirstOrDefault();
        }
    }
}
