using System;
using Flunt.Notifications;
using Flunt.Validations;
using Meta.TI.Domain.Commands.Contracts;

namespace Meta.TI.Domain.Commands
{

    public class DeletarCampanhaCommand : Notifiable, ICommand
    {
        public int Id { get; set; }

        public void Validate()
        {
            AddNotifications(
               new Contract()
               .Requires()
               .IsNotNull(Id, "Código da Campanha", "Campanha não encontrada.")
           );
        }
    }

}
