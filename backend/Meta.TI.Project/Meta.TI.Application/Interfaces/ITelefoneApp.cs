using System;
using System.Collections.Generic;
using System.Text;
using Meta.TI.Domain.Commands;

namespace Meta.TI.Application.Interfaces
{
    public interface ITelefoneApp
    {
        GenericCommandResult AlterarTelefoneHemocentro(AlterarTelefoneHemocentroCommand comando);
        GenericCommandResult ConsultarTelefoneHemocentro(ConsultarTelefoneHemocentroCommand comando);
    }
}
