using System;
using Flunt.Notifications;
using Flunt.Validations;
using Meta.TI.Domain.Commands.Contracts;

namespace Meta.TI.Domain.Commands
{

    public class DeletarFeedSolicitacaoCommand : Notifiable, ICommand
    {
        public int Id { get; set; }

        public void Validate()
        {
            AddNotifications(
               new Contract()
               .Requires()
               .IsNotNull(Id, "Código do Agendamento", "Agendamento não encontrado.")
           );
        }
    }

}
