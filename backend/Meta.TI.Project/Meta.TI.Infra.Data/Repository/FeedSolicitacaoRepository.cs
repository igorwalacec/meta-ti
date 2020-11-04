using System;
using System.Collections.Generic;
using System.Linq;
using Meta.TI.Domain.Interfaces;
using Meta.TI.Domain.Models;
using Meta.TI.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Meta.TI.Infra.Data.Repository
{
    public class FeedSolicitacaoRepository : Repository<FeedSolicitacao>, IFeedSolicitacaoRepository
    {
        public FeedSolicitacaoRepository(MetaTiContext context) : base(context)
        {
        }

        public List<FeedSolicitacao> ObterTodosFeedSolicitacao(DateTime dataAtual)
        {
            return DbSet.Where(x => (x.DataAlteracao == null ? x.DataCriacao : x.DataAlteracao) >= dataAtual.AddDays(-90))
                .Include(y => y.Hemocentro)
                .Include(z => z.Usuario)
                .Include(t => t.TipoSanguineo)
                .OrderByDescending(x => x.DataAlteracao == null ? x.DataCriacao : x.DataAlteracao)
                .ToList();
        }

        public List<FeedSolicitacao> ObterFeedSolicitacaoPorHemocentro(DateTime dataAtual, Guid idHemocentro)
        {
            return DbSet.Where(x => (x.DataAlteracao == null ? x.DataCriacao : x.DataAlteracao) >= dataAtual.AddDays(-90) && x.IdHemocentro == idHemocentro)
               .Include(y => y.Hemocentro)
               .Include(z => z.Usuario)
               .OrderByDescending(x => x.DataAlteracao == null ? x.DataCriacao : x.DataAlteracao)
               .ToList();
        }

        public FeedSolicitacao ObterFeedSolicitacaoPorUsuario(Guid idUsuario)
        {
            return DbSet.Where(x => x.IdUsuario == idUsuario).OrderByDescending(x => x.DataCriacao).FirstOrDefault();
        }

        public FeedSolicitacao ObterFeedSolicitacaoPorId(int id)
        {
            return DbSet.FirstOrDefault(x => x.Id == id);
        }

        public bool VerificarFeedSolicitacaoCPF(DateTime dataAtual, string CPF)
        {
            return DbSet.Where(x => (x.DataAlteracao == null ? x.DataCriacao : x.DataAlteracao) >= dataAtual.AddDays(-90) && x.Usuario.CPF.ToUpper().Equals(CPF.ToUpper())).Any();
        }

        public List<FeedSolicitacao> ObterFeedSolicitacaoPorTipoSanguineo(DateTime dataAtual, int idTipoSanguineo)
        {
            return DbSet.Where(x => (x.DataAlteracao == null ? x.DataCriacao : x.DataAlteracao) >= dataAtual.AddDays(-90) && x.IdTipoSanguineo == idTipoSanguineo)
               .Include(y => y.Hemocentro)
               .Include(z => z.Usuario)
               .OrderByDescending(x => x.DataAlteracao == null ? x.DataCriacao : x.DataAlteracao)
               .ToList();
        }
    }
}
