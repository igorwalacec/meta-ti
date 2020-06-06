using System;
using System.Collections.Generic;
using System.Text;
using Flunt.Notifications;
using Flunt.Validations;
using Meta.TI.Domain.Commands.Contracts;

namespace Meta.TI.Domain.Commands
{
    public class TokenCommand : Notifiable, ICommand
    {
        public string Email { get; set; }
        public string Senha { get; set; }
        public void Validate()
        {
            AddNotifications(
               new Contract()
               .Requires()
               .IsEmail(Email, "E-mail", "Por favor, digite um e-mail inválido")
               .IsNotNullOrEmpty(Email, "E-mail", "Por favor, digite seu email.")
               .IsNotNullOrEmpty(Senha, "Senha", "Por favor, digite sua senha.")
            );
        }
    }
}
