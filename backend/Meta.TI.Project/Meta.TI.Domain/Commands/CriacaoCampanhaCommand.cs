using System;
using Flunt.Notifications;
using Flunt.Validations;
using Meta.TI.Domain.Commands.Contracts;

namespace Meta.TI.Domain.Commands
{
    public class CriacaoCampanhaCommand : Notifiable, ICommand
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public Guid IdHemocentro { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                .Requires()
                .IsNotNullOrEmpty(Titulo, "Titulo", "Por favor digite o Titulo da campanha.")
                .IsNotNullOrEmpty(Descricao, "Descricao", "Por favor digite a descricao da campanha.")
                .IsNotEmpty(IdHemocentro, "Código do Hemocentro", "Hemocentro não encontrado.")
            );
        }
    }
}
