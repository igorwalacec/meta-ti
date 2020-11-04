using System;
using System.Collections.Generic;
using Meta.TI.Domain.Models;

namespace Meta.TI.Domain.Interfaces
{
    public interface INotificacoesRepository : IRepository<Notificacoes>
    {
        List<Notificacoes> ObterFeedSolicitacaoPorUsuario(Guid idUsuario);
    }
}
