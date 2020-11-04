using System;
using Meta.TI.Domain.Commands;

namespace Meta.TI.Application.Interfaces
{
    public interface INotificacoesApp : IDisposable
    {
        GenericCommandResult ConsultarNotificacoesPorIdUsuario(ConsultarNotificacoesPorIdUsuarioCommand command);
    }
}
