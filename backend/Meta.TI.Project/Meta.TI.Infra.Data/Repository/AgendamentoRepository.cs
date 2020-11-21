using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Meta.TI.Domain.Interfaces;
using Meta.TI.Domain.Models;
using Meta.TI.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Meta.TI.Infra.Data.Repository
{
    public class AgendamentoRepository : Repository<Agendamento>, IAgendamentoRepository
    {
        public AgendamentoRepository(MetaTiContext context) : base(context)
        {
        }

        public Agendamento ObterAgendamentoPorId(Guid id)
        {
            return DbSet.Where(x => x.Id == id)
                .Include(y => y.Usuario).ThenInclude(y => y.TipoSanguineo)
                .Include(z => z.Hemocentro)
                .FirstOrDefault();
        }

        public List<Agendamento> ObterAgendamentoPorUsuario(Guid idUsuario)
        {
            return DbSet.Where(x => x.IdUsuario == idUsuario)
               .Include(y => y.Usuario)
               .Include(z => z.Hemocentro)
               .OrderByDescending(x => x.DataAgendamento)
               .ToList();
        }

        public bool VerificarAgendamentoPorUsuario(Usuario usuario)
        {
            return DbSet.Where(x => x.IdUsuario == usuario.Id && x.DataAgendamento > DateTime.Now).Any();
        }
    }
}

