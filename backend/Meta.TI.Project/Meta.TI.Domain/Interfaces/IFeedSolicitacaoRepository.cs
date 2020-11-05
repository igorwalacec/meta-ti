using System;
using System.Collections.Generic;
using Meta.TI.Domain.Models;

namespace Meta.TI.Domain.Interfaces
{
    public interface IFeedSolicitacaoRepository : IRepository<FeedSolicitacao>
    {
        List<FeedSolicitacao> ObterTodosFeedSolicitacao(DateTime dataAtual);
        List<FeedSolicitacao> ObterFeedSolicitacaoPorHemocentro(DateTime dataAtual, Guid idHemocentro);
        List<FeedSolicitacao> ObterFeedSolicitacaoPorTipoSanguineo(DateTime dataAtual, int idTipoSanguineo);
        List<FeedSolicitacao> ExtracaoFeedSolicitacaoParaNotificacoes(Guid idusuario, int idCidade, int? idTipoSanguineo);
        FeedSolicitacao ObterFeedSolicitacaoPorUsuario(Guid idUsuario);
        FeedSolicitacao ObterFeedSolicitacaoPorId(int id);
        bool VerificarFeedSolicitacaoCPF(DateTime dataAtual, string CPF);
    }
}
