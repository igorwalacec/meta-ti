using System;
using System.Collections.Generic;
using System.Text;
using Meta.TI.Domain.Commands;

namespace Meta.TI.Application.Interfaces
{
    public interface IHistoricoAptidaoApp : IDisposable
    {
        GenericCommandResult CalcularDayOff(Guid usuarioId);
    }
}