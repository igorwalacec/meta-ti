using System;
using System.Collections.Generic;
using System.Text;
using Meta.TI.Domain.Commands;

namespace Meta.TI.Application.Interfaces
{
    public interface IDoacaoApp : IDisposable
    {
        GenericCommandResult CadastrarNovaDoacao(CadastrarNovaDoacaoCommand comando);
        GenericCommandResult ObterHistoricoDoacao(Guid idUsuario);
        GenericCommandResult ObterOrientacoesDoacao();
        GenericCommandResult BuscarStatusDoacao(StatusDoacaoCommand status);
    }
}
