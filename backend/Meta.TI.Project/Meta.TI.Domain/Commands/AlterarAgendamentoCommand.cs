using System;
using Flunt.Notifications;
using Flunt.Validations;
using Meta.TI.Domain.Commands.Contracts;

namespace Meta.TI.Domain.Commands
{
    public class AlterarAgendamentoCommand : Notifiable, ICommand
    {
        public Guid Id { get; set; }
        public Guid IdUsuario { get; set; }
        public Guid IdHemocentro { get; set; }
        public DateTime DataAgendamento { get; set; }

        public void Validate()
        {
            AddNotifications(
               new Contract()
               .Requires()
               .IsNotEmpty(Id, "Código do Agendamento", "Agendamento não encontrado.")
               .IsNotEmpty(IdUsuario, "Código do Usúário", "Usuário não encontrado.")
               .IsNotEmpty(IdHemocentro, "Código do Hemocentro", "Hemocentro não encontrado.")
               .IsNotNull(DataAgendamento, "Data Agendamento", "Por favor, digite a data do agendamento.")
           );
        }
    }
}
