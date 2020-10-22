using System;
using Flunt.Notifications;
using Flunt.Validations;
using Meta.TI.Domain.Commands.Contracts;

namespace Meta.TI.Domain.Commands
{

    public class ConsultarCampanhaPorHemocentroCommand : Notifiable, ICommand
    {
        public Guid IdHemocentro { get; set; }
        public DateTime DataAtual { get; set; }

        public void Validate()
        {
            AddNotifications(
               new Contract()
               .Requires()
               .IsNotEmpty(IdHemocentro, "Código do Hemocentro", "Hemocentro não encontrado.")
               .IsNullOrNullable(DataAtual, "Data Atual", "Data Atual não encontrada.")
           );
        }
    }
}
