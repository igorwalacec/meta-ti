using System;
using System.Collections.Generic;
using System.Text;
using Flunt.Notifications;
using Flunt.Validations;
using Meta.TI.Domain.Commands.Contracts;

namespace Meta.TI.Domain.Commands
{
    public class ObterExpedientePorIdHemocentroCommand : Notifiable, ICommand
    {
        public Guid IdHemocentro { get; set; }
        public void Validate()
        {
            AddNotifications(
               new Contract()
               .Requires()
               .AreEquals(IdHemocentro,Guid.Empty, "Hemocentro inválido", "Hemocentro inválido.")
           );
        }
    }
}
