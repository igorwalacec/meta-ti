using Meta.TI.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Meta.TI.Application.Interfaces
{
    public interface ICidadeService : IDisposable
    {
        IEnumerable<CidadeViewModel> ObterCidadesPorEstado(int idEstado);
    }
}
