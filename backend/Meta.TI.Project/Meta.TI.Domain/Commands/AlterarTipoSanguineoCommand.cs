using System;
using Flunt.Notifications;
using Flunt.Validations;
using Meta.TI.Domain.Commands.Contracts;

namespace Meta.TI.Domain.Commands
{
    public class AlterarTipoSanguineoCommand : Notifiable, ICommand
    {
        public Guid IdUsuario { get; set; }
        public int IdTipoSanguineo { get; set; }
        public void Validate()
        {
            AddNotifications(
                new Contract()
                .Requires()
                .IsNotNull(IdTipoSanguineo, "Tipo Sanguíneo", "Informe seu tipo sanguíneo")
                .AreNotEquals(IdTipoSanguineo,0, "Tipo Sanguíneo", "Informe seu tipo sanguíneo")
                .IsNotEmpty(IdUsuario, "Código do Usúario", "Usuário não encontrado")
            );


        }
    }
}
