using System;
using Flunt.Br.Extensions;
using Flunt.Notifications;
using Flunt.Validations;
using Meta.TI.Domain.Commands.Contracts;

namespace Meta.TI.Domain.Commands
{
    public class CriacaoUsuarioCommand : Notifiable, ICommand
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string RG { get; set; }
        public string CPF { get; set; }
        public int IdTipoSexo { get; set; }
        public int? IdTipoSanguineo { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Logradouro { get; set; }
        public string Complemento { get; set; }
        public string Numero { get; set; }
        public string Cep { get; set; }
        public int IdCidade { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                .Requires()
                .IsNotNullOrEmpty(Nome,"Nome","Por favor, digite seu nome.")
                .IsNotNullOrEmpty(Sobrenome, "Sobrenome", "Por favor, digite seu sobrenome.")
                .AreNotEquals(IdTipoSexo, 0,"Sexo", "Por favor, selecione seu sexo.")
                .IsEmail(Email, "Email", "Por favor, digite um e-mail válido.")
                .IsNotNullOrEmpty(Senha, "Senha","Por favor, senha obrigatória.")
                .IsNotNullOrEmpty(RG, "RG", "Por favor, informe seu RG.")
                .HasExactLengthIfNotNullOrEmpty(RG, 9, "RG","RG deve ter 9 digitos obrigatoriamente.")
                .HasExactLengthIfNotNullOrEmpty(CPF, 11, "CPF", "CPF deve ter 11 digitos obrigatoriamente.")
                .IsNotNullOrEmpty(CPF, "CPF", "Por favor, informe seu CPF.")
                .IsCpf(CPF, "CPF", "CPF inválido.")
                .IsNotNull(DataNascimento, "Data Nascimento", "Por favor, digite sua data de nascimento.")
                .IsNotNullOrEmpty(Logradouro, "Logradouro", "Por favor, digite o seu logradouro.")
                .IsNotNullOrEmpty(Numero, "Número", "Por favor, digite um número.")
                .IsNotNullOrEmpty(Cep, "CEP", "Por favor, digite seu CEP.")
                .AreNotEquals(IdCidade, 0,"Cidade", "Por favor, selecione uma cidade.")
            );
        }
    }
}
