using System;
using Flunt.Notifications;
using Flunt.Validations;
using Meta.TI.Domain.Commands.Contracts;
using Meta.TI.Domain.Dto;
using Meta.TI.Domain.Models;

namespace Meta.TI.Domain.Commands
{
    public class AlterarEnderecoUsuarioCommand : Notifiable, ICommand
    {
        public Guid IdUsuario { get; set; }
        public EnderecoDto DadosEndereco { get; set; }
        public void Validate()
        {
            AddNotifications(
                new Contract()
                .Requires()
                .IsNotNull(DadosEndereco, "Dados do Endereco", "Informe seu endereço")
                .IsNotEmpty(IdUsuario, "Código do Usúario", "Usuário não encontrado")
            );


        }
    }
}
