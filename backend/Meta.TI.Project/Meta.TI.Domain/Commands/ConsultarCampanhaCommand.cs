using System;
using Flunt.Notifications;
using Flunt.Validations;
using Meta.TI.Domain.Commands.Contracts;

namespace Meta.TI.Domain.Commands
{

    public class ConsultarCampanhaCommand : Notifiable, ICommand
    {
        public DateTime DataAtual { get; set; }

        public void Validate()
        {
            AddNotifications(
               new Contract()
               .Requires()
               .IsNullOrNullable (DataAtual, "Data Atual", "Data Atual não encontrada.")
           );
        }
    }

}
