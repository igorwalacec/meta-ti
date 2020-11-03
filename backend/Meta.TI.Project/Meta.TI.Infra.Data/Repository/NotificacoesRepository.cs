using System;
using System.Collections.Generic;
using System.Linq;
using Meta.TI.Domain.Interfaces;
using Meta.TI.Domain.Models;
using Meta.TI.Infra.Data.Context;

namespace Meta.TI.Infra.Data.Repository
{
    public class NotificacoesRepository : Repository<Notificacoes>, INotificacoesRepository
    {
        public NotificacoesRepository(MetaTiContext context) : base(context)
        {
        }

        public List<Notificacoes> ObterFeedSolicitacaoPorUsuario(Guid idUsuario)
        {
            return DbSet.Where(x => x.IdUsuario == idUsuario).OrderByDescending(x => x.DataCriacao).ToList();
        }
    }
}
