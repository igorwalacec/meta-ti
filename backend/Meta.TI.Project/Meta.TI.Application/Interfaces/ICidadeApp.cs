using Meta.TI.Application.ViewModels;
using Meta.TI.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Meta.TI.Application.Interfaces
{
    public interface ICidadeApp : IDisposable
    {
        GenericCommandResult ObterCidadesPorEstado(int idEstado);
    }
}
