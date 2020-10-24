using System;
using Flunt.Notifications;
using Flunt.Validations;
using Meta.TI.Domain.Commands.Contracts;

namespace Meta.TI.Domain.Commands
{
    public class AdicionarPatrocinadorCommand : Notifiable, ICommand
    {
        public string NomePatrocinador { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                .Requires()
                .IsNotNull(NomePatrocinador, "Nome Patrocinador", "Por Favor, Nome do Patrocinador não pode ser vazio!")                
            );
        }
    }
}
