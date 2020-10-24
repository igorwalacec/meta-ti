using System;
using System.Collections.Generic;
using System.Text;
using Meta.TI.Domain.Commands;

namespace Meta.TI.Application.Interfaces
{
    public interface IAptidaoApp : IDisposable
    {
        GenericCommandResult ObterQuestoesAptidao();
        GenericCommandResult CadastrarRespostasAptidao(RespostaAptidaoCommand respostasAptidao);
        GenericCommandResult CalcularDayOff(StatusDoacaoCommand status);
    }
}
