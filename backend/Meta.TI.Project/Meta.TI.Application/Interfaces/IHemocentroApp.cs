using System;
using Meta.TI.Domain.Commands;

namespace Meta.TI.Application.Interfaces
{
    public interface IHemocentroApp : IDisposable
    {
        GenericCommandResult CriarHemocentro(CriacaoHemocentroCommand comando);
        GenericCommandResult AlterarStatusHemocentro(AlterarAtivoHemocentroCommand comando);
    }
}
