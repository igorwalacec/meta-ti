using System;
using System.Collections.Generic;
using System.Text;
using Flunt.Notifications;
using Flunt.Validations;
using Meta.TI.Domain.Commands.Contracts;
using Meta.TI.Domain.Dto;
using Meta.TI.Domain.Models;

namespace Meta.TI.Domain.Commands
{
    public class AlterarTelefoneHemocentroCommand : Notifiable, ICommand
    {       
        public List<TelefoneDto> DadosTelefone { get; set; }
        
        public void Validate()
        {
            AddNotifications(
                new Contract()
                .Requires()
                .IsNotNull(DadosTelefone, "Dados do Telefone", "Informe seu telefone")
            );
        }        
    }
}
