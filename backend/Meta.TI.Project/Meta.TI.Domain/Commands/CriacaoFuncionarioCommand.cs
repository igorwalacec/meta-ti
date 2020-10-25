using System;
using Flunt.Notifications;
using Flunt.Validations;
using Meta.TI.Domain.Commands.Contracts;

namespace Meta.TI.Domain.Commands
{
    public class CriacaoFuncionarioCommand : Notifiable, ICommand
    {
        public string NomeCompleto { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string CPF { get; set; }
        public Guid? IdHemocentro { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                .Requires()
                .IsNotNullOrEmpty(NomeCompleto, "NomeCompleto", "Por favor, digite seu nome.")
                .IsEmail(Email, "Email", "Por favor, digite um e-mail válido.")
                .IsNotNullOrEmpty(Senha, "Senha", "Por favor, senha obrigatória.")
                .HasExactLengthIfNotNullOrEmpty(CPF, 11, "CPF", "CPF deve ter 11 digitos obrigatoriamente.")
            );
        }
    }
}
