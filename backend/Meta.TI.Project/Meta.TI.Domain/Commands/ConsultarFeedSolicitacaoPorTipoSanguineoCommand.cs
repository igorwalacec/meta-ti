using System;
using Flunt.Notifications;
using Flunt.Validations;
using Meta.TI.Domain.Commands.Contracts;

namespace Meta.TI.Domain.Commands
{
    public class ConsultarFeedSolicitacaoPorTipoSanguineoCommand : Notifiable, ICommand
    {
        public int IdTipoSanguineo { get; set; }
        public DateTime DataAtual { get; set; }

        public void Validate()
        {
            AddNotifications(
               new Contract()
               .Requires()
               .IsNotNull(IdTipoSanguineo, "Tipo Sanguineo", "Por favor, selecione o tipo sanguineo.")
               .IsNullOrNullable(DataAtual, "Data Atual", "Data atual não encontrada")
           );
        }
    }
}
