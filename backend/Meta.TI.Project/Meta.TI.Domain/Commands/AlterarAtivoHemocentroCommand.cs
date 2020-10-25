using System;
using Flunt.Notifications;
using Flunt.Validations;
using Meta.TI.Domain.Commands.Contracts;

namespace Meta.TI.Domain.Commands
{
    public class AlterarAtivoHemocentroCommand : Notifiable, ICommand
    {
            public Guid IdHemocentro { get; set; }
            public bool Ativo { get; set; }
            public void Validate()
            {
                AddNotifications(
                    new Contract()
                    .Requires()
                    .IsNotNull(Ativo, "Ativo", "Informe se o status do hemocentro")
                    .IsNotEmpty(IdHemocentro, "Código do Hemocentro", "Hemocentro não encontrado")
                );
            }
    }
}
