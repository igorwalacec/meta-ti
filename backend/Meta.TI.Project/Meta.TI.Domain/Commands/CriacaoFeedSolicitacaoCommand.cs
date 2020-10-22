using System;
using Flunt.Notifications;
using Flunt.Validations;
using Meta.TI.Domain.Commands.Contracts;

namespace Meta.TI.Domain.Commands
{
    public class CriacaoFeedSolicitacaoCommand : Notifiable, ICommand
    {
        public string Descricao { get; set; }
        public string CPF { get; set; }
        public Guid IdHemocentro { get; set; }
        public int IdTipoSanguineo { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                .Requires()
                .IsNotNullOrEmpty(CPF, "CPF", "Por favor digite o CPF do usuário.")
                .IsNotEmpty(IdHemocentro, "Código do Hemocentro", "Hemocentro não encontrado.")
                .IsNotNull(IdTipoSanguineo, "Tipo Sanguineo", "Por favor, selecione o tipo sanguineo.")
            );
        }
    }
}
