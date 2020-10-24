using System;
using Flunt.Notifications;
using Flunt.Validations;
using Meta.TI.Domain.Commands.Contracts;

namespace Meta.TI.Domain.Commands
{

    public class CompartilhamentoWhatsappCommand : Notifiable, ICommand
    {
        public string NumeroCelular { get; set; }
        public string Mensagem { get; set; }
        public Guid IdUsuario { get; set; }

        public void Validate()
        {
            AddNotifications(
               new Contract()
               .Requires()
               .IsNotNullOrEmpty(NumeroCelular, "Numero do Celular", "Por favor digite o Número do seu amigo.")
               .IsNotNullOrEmpty(Mensagem, "Titulo", "Por favor digite a mensagem de envio.")
               .IsNotEmpty(IdUsuario, "Código do Usuário", "Usuário não encontrado.")
           );
        }
    }

}
