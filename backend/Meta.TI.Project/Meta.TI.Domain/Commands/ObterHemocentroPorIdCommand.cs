using System;
using Flunt.Notifications;
using Flunt.Validations;
using Meta.TI.Domain.Commands.Contracts;

namespace Meta.TI.Domain.Commands
{
    public class ObterHemocentroPorIdCommand : Notifiable, ICommand
    {
        public Guid IdHemocentro { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                .Requires()
                .IsNotNull(IdHemocentro, "Id Hemocentro", "Id Hemocentro não pode ser nulo!")
            );
        }
    }
}
