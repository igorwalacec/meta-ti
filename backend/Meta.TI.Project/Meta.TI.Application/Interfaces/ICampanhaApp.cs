using System;
using System.Collections.Generic;
using System.Text;
using Meta.TI.Domain.Commands;

namespace Meta.TI.Application.Interfaces
{
    public interface ICampanhaApp : IDisposable
    {
        GenericCommandResult ObterTodasCampanhas();
        GenericCommandResult ObterCampanhaPorHemocentro(Guid idHemocentro);
        GenericCommandResult CriacaoCampanha(CriacaoCampanhaCommand command);
        GenericCommandResult AlterarCampanha(AlterarCampanhaCommand command);
        GenericCommandResult DeletarCampanha(int idCampanha);
    }
}
