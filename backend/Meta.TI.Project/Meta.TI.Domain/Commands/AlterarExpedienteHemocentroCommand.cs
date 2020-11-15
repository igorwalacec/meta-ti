using System.Collections.Generic;
using Flunt.Notifications;
using Flunt.Validations;
using Meta.TI.Domain.Commands.Contracts;
using Meta.TI.Domain.Dto;

namespace Meta.TI.Domain.Commands
{
    public class AlterarExpedienteHemocentroCommand : Notifiable, ICommand
    {
        public List<ExpedienteDto> DadosExpediente { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                .Requires()
                .IsNotNull(DadosExpediente, "Dados dos Expedientes", "Informe seus expedientes")
            );
        }
    }
}
