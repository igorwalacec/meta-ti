using System;
using System.Collections.Generic;
using System.Text;
using Meta.TI.Domain.Commands;

namespace Meta.TI.Application.Interfaces
{
    public interface IFeedSolicitacaoApp : IDisposable
    {
        GenericCommandResult ObterTodosFeedSolicitacao();
        GenericCommandResult ObterFeedSolicitacaoPorHemocentro(Guid guid);
        GenericCommandResult CriacaoFeedSolicitacao(CriacaoFeedSolicitacaoCommand command);
        GenericCommandResult AlterarFeedSolicitacao(AlterarFeedSolicitacaoCommand command);
        GenericCommandResult DeletarFeedSolicitacao(int idFeedSolicitacao);
    }
}
