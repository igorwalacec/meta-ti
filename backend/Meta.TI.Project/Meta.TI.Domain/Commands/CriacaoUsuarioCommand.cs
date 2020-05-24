using System;
using Flunt.Br.Extensions;
using Flunt.Notifications;
using Flunt.Validations;
using Meta.TI.Domain.Commands.Contracts;
using Meta.TI.Domain.Models;

namespace Meta.TI.Domain.Commands
{
    public class CriacaoUsuarioCommand : Notifiable, ICommand
    {
        public Usuario Usuario { get; set; }
        public CriacaoUsuarioCommand()
        {

        }
        public CriacaoUsuarioCommand(Usuario usuario)
        {
            Usuario = usuario;
        }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                .Requires()
                .IsNotNullOrEmpty(Usuario.Nome,"Nome","Por favor, digite seu nome.")
                .IsNotNullOrEmpty(Usuario.Sobrenome, "Sobrenome", "Por favor, digite seu sobrenome.")
                .IsEmail(Usuario.Email, "Email", "Por favor, digite um e-mail válido.")
                .IsNotNullOrEmpty(Usuario.Senha, "Senha","Por favor, senha obrigatória.")
                .HasExactLengthIfNotNullOrEmpty(Usuario.RG, 9, "RG","RG deve ter 9 digitos obrigatoriamente.")
                .HasExactLengthIfNotNullOrEmpty(Usuario.CPF, 11, "CPF", "CPF deve ter 11 digitos obrigatoriamente.")
                .IsCpf(Usuario.CPF, "CPF", "CPF inválido.")
                .IsNotNull(Usuario.DataNascimento, "Data Nascimento", "Por favor, digite sua data de nascimento.")
                .IsNotNullOrEmpty(Usuario.Endereco.Logradouro, "Logradouro", "Por favor, digite o seu logradouro.")
                .IsNotNullOrEmpty(Usuario.Endereco.Numero, "Número", "Por favor, digite um número.")
                .IsNotNullOrEmpty(Usuario.Endereco.Cep, "CEP", "Por favor, digite seu CEP.")
                .IsNotNull(Usuario.Endereco.IdCidade, "Cidade", "Por favor, selecione uma cidade.")
            );
        }
    }
}
