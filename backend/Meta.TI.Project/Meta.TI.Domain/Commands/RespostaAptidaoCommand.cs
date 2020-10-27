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
    public class RespostaAptidaoCommand : Notifiable, ICommand
    {
        public Guid IdUsuario { get; set; }
        public List<RespostaAptidaoDto> RespostasAptidao { get; set; } 

        public void Validate()
        {
            AddNotifications(
                new Contract()
                .Requires()
                .IsNotNull(RespostasAptidao, "Respostas da Aptidão", "Por favor, responda todas as perguntas.")            
            );
        }
    }
}
