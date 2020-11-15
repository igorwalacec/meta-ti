using System;
using System.Collections.Generic;
using System.Linq;
using Meta.TI.Domain.Interfaces;
using Meta.TI.Domain.Models;
using Meta.TI.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Meta.TI.Infra.Data.Repository
{
    public class NotificacoesRepository : Repository<Notificacoes>, INotificacoesRepository
    {
        public NotificacoesRepository(MetaTiContext context) : base(context)
        {
        }

        public List<Notificacoes> ObterNotificacoesPorUsuario(Guid idUsuario)
        {
            return DbSet.Where(x => x.IdUsuario == idUsuario)
                .Include(y => y.Usuario)
                .Include(z => z.Hemocentro)
                .OrderByDescending(x => x.DataCriacao)
                .ToList();
        }

        public void RemoverNotificacoesPorUsuario(Guid idUsuario)
        {
            var notificacoes = DbSet.Where(x => x.IdUsuario == idUsuario).ToList();

            DbSet.RemoveRange(notificacoes);

            this.Salvar();
        }

    }
}
