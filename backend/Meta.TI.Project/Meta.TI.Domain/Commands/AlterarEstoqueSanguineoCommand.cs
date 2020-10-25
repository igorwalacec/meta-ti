using System.Collections.Generic;
using Flunt.Notifications;
using Flunt.Validations;
using Meta.TI.Domain.Commands.Contracts;
using Meta.TI.Domain.Models;

namespace Meta.TI.Domain.Commands
{
    public class AlterarEstoqueSanguineoCommand : Notifiable, ICommand
    {
        public List<EstoqueSanguineo> DadosEstoqueSanguineo { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                .Requires()
                .IsNotNull(DadosEstoqueSanguineo, "Dados dos Estoques Sanguineos", "Informe seus estoques sanguineos")
            );
        }
    }
}
