using System;
using Flunt.Notifications;
using Flunt.Validations;
using Meta.TI.Domain.Commands.Contracts;

namespace Meta.TI.Domain.Commands
{
    public class AdicionarLevelCommand : Notifiable, ICommand
    {
        public int Nivel { get; set; }
        public int QuantidadeDoacao { get; set; }
        public int IdRecompensa { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                .Requires()
                .IsNotNull(Nivel, "Nivel", "Informe um nivel.")
                .IsNotNull(QuantidadeDoacao, "Quantidade Doacao", "Informe quantas doação são necessarias para atingir esse nivel.")
                .AreNotEquals(IdRecompensa, 0, "Id Recompensa", "Escolha uma recompensa para esse nivel.")
            );
        }
    }
}
