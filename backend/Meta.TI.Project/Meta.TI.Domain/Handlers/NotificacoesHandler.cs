using System;
using System.Collections.Generic;
using System.Text;
using Flunt.Notifications;
using Meta.TI.Domain.Commands;
using Meta.TI.Domain.Commands.Contracts;
using Meta.TI.Domain.Handlers.Contracts;
using Meta.TI.Domain.Interfaces;

namespace Meta.TI.Domain.Handlers
{
    public class NotificacoesHandler : Notifiable,
                                  IHandler<ConsultarNotificacoesPorIdUsuarioCommand>
    {
        private readonly INotificacoesRepository notificacoesRepository;

        public NotificacoesHandler(INotificacoesRepository _notificacoesRepository)
        {
            notificacoesRepository = _notificacoesRepository;
        }

        public ICommandResult Handle(ConsultarNotificacoesPorIdUsuarioCommand command)
        {
            var notificacoes = notificacoesRepository.ObterFeedSolicitacaoPorUsuario(command.IdUsuario);

            return new GenericCommandResult(true, notificacoes);
        }
    }
}
