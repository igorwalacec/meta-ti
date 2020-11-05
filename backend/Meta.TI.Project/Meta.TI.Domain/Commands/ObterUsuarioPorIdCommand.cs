using System;
using Flunt.Notifications;
using Flunt.Validations;
using Meta.TI.Domain.Commands.Contracts;

namespace Meta.TI.Domain.Commands
{
    public class ObterUsuarioPorIdCommand : Notifiable, ICommand
    {
        public Guid IdUsuario { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                .Requires()
                .IsNotNull(IdUsuario, "Id Usuario", "Id Usuario não pode ser nulo!")
            );
        }
    }
}
