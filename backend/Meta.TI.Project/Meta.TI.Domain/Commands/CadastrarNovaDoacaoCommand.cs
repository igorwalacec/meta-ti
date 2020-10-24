using System;
using Flunt.Br.Extensions;
using Flunt.Notifications;
using Flunt.Validations;
using Meta.TI.Domain.Commands.Contracts;

namespace Meta.TI.Domain.Commands
{
    public class CadastrarNovaDoacaoCommand : Notifiable, ICommand
    {
        public Guid IdUsuario { get; set; }
        public DateTime DataCadastro { get; set; }
        public Guid IdHemocentro { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                .Requires()
                .IsNotNull(DataCadastro, "Data Cadastro", "Por favor, informe a data de cadastro.")
                .AreNotEquals(IdHemocentro, 0,"Hemocentro", "Por favor, selecione um hemocentro.")
            );
        }
    }
}
