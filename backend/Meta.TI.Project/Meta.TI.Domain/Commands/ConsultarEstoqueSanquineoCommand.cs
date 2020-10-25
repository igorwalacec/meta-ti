using System;
using System.Collections.Generic;
using System.Text;
using Flunt.Notifications;
using Flunt.Validations;
using Meta.TI.Domain.Commands.Contracts;

namespace Meta.TI.Domain.Commands
{
    public class ConsultarEstoqueSanquineoCommand : Notifiable, ICommand
    {
        public Guid IdHemocentro { get; set; }
        public int IdTipoSanguineo { get; set; }
        public void Validate()
        {
            AddNotifications(
                new Contract()
                .Requires()
                .IsNotNull(IdTipoSanguineo, "Tipo Sanguíneo", "Informe seu tipo sanguíneo")
                .AreNotEquals(IdTipoSanguineo, 0, "Tipo Sanguíneo", "Informe seu tipo sanguíneo")
                .IsNotEmpty(IdHemocentro, "Código do Usúario", "Hemocentro não encontrado")
            );
        }
    }
}
