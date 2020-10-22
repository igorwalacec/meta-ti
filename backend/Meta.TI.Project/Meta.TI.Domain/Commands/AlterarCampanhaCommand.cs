using System;
using Flunt.Notifications;
using Flunt.Validations;
using Meta.TI.Domain.Commands.Contracts;
namespace Meta.TI.Domain.Commands
{
    public class AlterarCampanhaCommand : Notifiable, ICommand
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public Guid IdHemocentro { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                .Requires()
                .IsNotNull(Id, "Código da Campanha", "Campaanha não encontrada.")
                .IsNotNullOrEmpty(Titulo, "Titulo", "Por favor digite o Titulo da campanha.")
                .IsNotNullOrEmpty(Descricao, "Descricao", "Por favor digite a descricao da campanha.")
                .IsNotEmpty(IdHemocentro, "Código do Hemocentro", "Hemocentro não encontrado.")
            );
        }
    }
}
