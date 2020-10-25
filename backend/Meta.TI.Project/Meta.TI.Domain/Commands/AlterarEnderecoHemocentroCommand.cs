using System;
using Flunt.Notifications;
using Flunt.Validations;
using Meta.TI.Domain.Commands.Contracts;
using Meta.TI.Domain.Models;

namespace Meta.TI.Domain.Commands
{
    public class AlterarEnderecoHemocentroCommand : Notifiable, ICommand
    {
        public Guid IdHemocentro { get; set; }
        public Endereco DadosEndereco { get; set; }
        public void Validate()
        {
            AddNotifications(
                new Contract()
                .Requires()
                .IsNotNull(DadosEndereco, "Dados do Endereco", "Informe seu endereço")
                .IsNotEmpty(IdHemocentro, "Código do Hemocentro", "Hemocentro não encontrado")
            );


        }
    }
}
