using System;
using Flunt.Notifications;
using Flunt.Validations;
using Meta.TI.Domain.Commands.Contracts;

namespace Meta.TI.Domain.Commands
{
    public class AdicionarRecompensasCommand : Notifiable, ICommand
    {
        public string Descricao { get; set; }
        public int IdPatrocinador { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                .Requires()
                .IsNotNull(Descricao, "Descricao", "Informe a descrição da recompensa.")
                .AreNotEquals(IdPatrocinador, 0, "Id Patrocinador", "Escolha um patrocinador para essa recompensa.")                
            );
        }
    }
}
