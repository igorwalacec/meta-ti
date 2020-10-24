using System;
using Flunt.Notifications;
using Flunt.Validations;
using Meta.TI.Domain.Commands.Contracts;

namespace Meta.TI.Domain.Commands
{
    public class DesativarLevelPorIdCommand : Notifiable, ICommand
    {
        public int IdDesativado { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                .Requires()                
                .IsNotNull(IdDesativado, "Id Desativado", "Id Desativado não pode ser nulo!")
            );
        }
    }
}
