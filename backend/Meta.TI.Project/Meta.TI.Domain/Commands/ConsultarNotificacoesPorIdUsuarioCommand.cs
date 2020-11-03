using System;
using Flunt.Notifications;
using Flunt.Validations;
using Meta.TI.Domain.Commands.Contracts;

namespace Meta.TI.Domain.Commands
{
    public class ConsultarNotificacoesPorIdUsuarioCommand : Notifiable, ICommand
    {
        public Guid IdUsuario { get; set; }

        public void Validate()
        {
            AddNotifications(
               new Contract()
               .Requires()
               .IsNotEmpty(IdUsuario, "Código do Usuario", "Usuario não encontrado.")
           );
        }
    }
}
