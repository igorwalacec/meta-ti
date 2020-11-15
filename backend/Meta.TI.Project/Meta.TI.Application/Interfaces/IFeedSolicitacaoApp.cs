using System;
using System.Collections.Generic;
using System.Text;
using Meta.TI.Domain.Commands;

namespace Meta.TI.Application.Interfaces
{
    public interface IFeedSolicitacaoApp : IDisposable
    {
        GenericCommandResult ObterTodosFeedSolicitacao(ConsultarFeedSolicitacaoCommand command);
        GenericCommandResult ObterFeedSolicitacaoPorHemocentro(ConsultarFeedSolicitacaoPorHemocentroCommand command);
        GenericCommandResult ObterFeedSolicitacaoPorTipoSanguineo(ConsultarFeedSolicitacaoPorTipoSanguineoCommand command);
        GenericCommandResult ObterFeedSolicitacaoPorUsuario(ObterFeedSolicitacaoPorIdUsuarioCommand command);
        GenericCommandResult CriacaoFeedSolicitacao(CriacaoFeedSolicitacaoCommand command);
        GenericCommandResult AlterarFeedSolicitacao(AlterarFeedSolicitacaoCommand command);
        GenericCommandResult DeletarFeedSolicitacao(DeletarFeedSolicitacaoCommand command);
    }
}
