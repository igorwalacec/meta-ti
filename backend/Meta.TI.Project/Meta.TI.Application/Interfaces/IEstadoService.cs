using Meta.TI.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Meta.TI.Application.Interfaces
{
    public interface IEstadoService : IDisposable
    {
        IEnumerable<EstadoViewModel> ObterEstados();
    }
}
