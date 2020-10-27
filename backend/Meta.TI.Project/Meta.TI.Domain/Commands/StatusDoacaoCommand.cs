using System;
using System.Collections.Generic;
using System.Text;
using Flunt.Notifications;
using Flunt.Validations;
using Meta.TI.Domain.Commands.Contracts;

namespace Meta.TI.Domain.Commands
{
    public class StatusDoacaoCommand : Notifiable, ICommand
    {
        public Guid IdUsuario { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                .Requires()
                .IsNotNull(IdUsuario, "IdUsuario", "IdUsuario não pode ser nulo")
                );
        }
    }
}
