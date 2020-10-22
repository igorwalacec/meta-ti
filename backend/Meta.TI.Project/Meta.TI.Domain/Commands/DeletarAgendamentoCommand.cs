using System;
using Flunt.Notifications;
using Flunt.Validations;
using Meta.TI.Domain.Commands.Contracts;

namespace Meta.TI.Domain.Commands
{
    public class DeletarAgendamentoCommand : Notifiable, ICommand
    {
        public Guid Id { get; set; }

        public void Validate()
        {
            AddNotifications(
               new Contract()
               .Requires()
               .IsNotEmpty(Id, "Código do Agendamento", "Agendamento não encontrado.")
           );
        }
    }
}
