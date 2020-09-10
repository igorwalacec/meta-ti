using System;
using System.Collections.Generic;
using System.Text;
using Meta.TI.Domain.Commands;

namespace Meta.TI.Application.Interfaces
{
    public interface IQuestoesAptidaoApp : IDisposable
    {
        GenericCommandResult ObterQuestoesAptidao();
    }
}
