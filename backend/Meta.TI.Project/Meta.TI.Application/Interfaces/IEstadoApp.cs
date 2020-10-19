using System;
using Meta.TI.Domain.Commands;

namespace Meta.TI.Application.Interfaces
{
    public interface IEstadoApp : IDisposable
    {
        GenericCommandResult ObterEstados();
    }
}
