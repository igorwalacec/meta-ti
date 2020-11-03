using System;
using System.Collections.Generic;
using System.Text;
using Flunt.Notifications;
using Meta.TI.Domain.Commands;
using Meta.TI.Domain.Commands.Contracts;
using Meta.TI.Domain.Handlers.Contracts;
using Meta.TI.Domain.Interfaces;
using Meta.TI.Domain.Models;

namespace Meta.TI.Domain.Handlers
{
    public class FeedSolicitacaoHandler : Notifiable,
                                    IHandler<ConsultarFeedSolicitacaoCommand>,
                                    IHandler<ConsultarFeedSolicitacaoPorHemocentroCommand>,
                                    IHandler<CriacaoFeedSolicitacaoCommand>,
                                    IHandler<AlterarFeedSolicitacaoCommand>,
                                    IHandler<DeletarFeedSolicitacaoCommand>
    {
        private readonly IFeedSolicitacaoRepository feedSolicitacaoRepository;
        private readonly IUsuarioRepository usuarioRepository;
        private readonly IHemocentroRepository hemocentroRepository;
        private readonly ITipoSanguineoRepository tipoSanguineoRepository;

        public FeedSolicitacaoHandler(IFeedSolicitacaoRepository _feedSolicitacaoRepository,
                                      IUsuarioRepository _usuarioRepository,
                                      IHemocentroRepository _hemocentroRepository,
                                      ITipoSanguineoRepository _tipoSanguineoRepository)
        {
            feedSolicitacaoRepository = _feedSolicitacaoRepository;
            usuarioRepository = _usuarioRepository;
            hemocentroRepository = _hemocentroRepository;
            tipoSanguineoRepository = _tipoSanguineoRepository;
        }

        public ICommandResult Handle(ConsultarFeedSolicitacaoCommand command)
        {
            var feedSolicitacoes = feedSolicitacaoRepository.ObterTodosFeedSolicitacao(command.DataAtual);

            return new GenericCommandResult(true, feedSolicitacoes);
        }

        public ICommandResult Handle(ConsultarFeedSolicitacaoPorHemocentroCommand command)
        {
            var feedSolicitacoes = feedSolicitacaoRepository.ObterFeedSolicitacaoPorHemocentro(command.DataAtual, command.IdHemocentro);

            return new GenericCommandResult(true, feedSolicitacoes);
        }

        public ICommandResult Handle(ConsultarFeedSolicitacaoPorTipoSanguineoCommand command)
        {
            var feedSolicitacoes = feedSolicitacaoRepository.ObterFeedSolicitacaoPorTipoSanguineo(command.DataAtual, command.IdTipoSanguineo);

            return new GenericCommandResult(true, feedSolicitacoes);
        }

        public ICommandResult Handle(CriacaoFeedSolicitacaoCommand command)
        {
            var hemocentro = hemocentroRepository.ObterPorId(command.IdHemocentro);
            var usuario = usuarioRepository.ObterUsuarioPorCPF(command.CPF);
            var tipoSanguineo = tipoSanguineoRepository.ObterPorId(command.IdTipoSanguineo);

            command.Validate();
            if (command.Invalid)
            {
                return new GenericCommandResult(false, "Ops, parece seu cadastro está inválido.", command.Notifications);
            }
            if (!usuarioRepository.VerificarExistenciaCPF(command.CPF))
            {
                command.AddNotification(new Notification("CPF", "Usuário não cadastrado na plataforma!"));
                return new GenericCommandResult(false, "Ops, parece seu cadastro está inválido.", command.Notifications);
            }
            if (!hemocentroRepository.VerificarExistenciaCNPJ(hemocentro.CNPJ))
            {
                command.AddNotification(new Notification("CNPJ", "Hemocentro não cadastrado na plataforma!"));
                return new GenericCommandResult(false, "Ops, parece seu cadastro está inválido.", command.Notifications);
            }
            if (feedSolicitacaoRepository.VerificarFeedSolicitacaoCPF(DateTime.Now, command.CPF))
            {
                command.AddNotification(new Notification("CPF", "CPF já cadastrado no feed de solicitações!"));
                return new GenericCommandResult(false, "Ops, parece seu cadastro está inválido.", command.Notifications);
            }

            var feedSolicitacao = new FeedSolicitacao(
                command.Descricao,
                usuario,
                hemocentro,
                tipoSanguineo
            );

            feedSolicitacao.SetarDataCriacao(DateTime.Now);
            feedSolicitacaoRepository.Adicionar(feedSolicitacao);
            var novoFeedSolicitacao = feedSolicitacaoRepository.ObterFeedSolicitacaoPorUsuario(usuario.Id);

            return new GenericCommandResult(true, "Feed de solicitação cadastrado!", novoFeedSolicitacao);            
        }

        public ICommandResult Handle(AlterarFeedSolicitacaoCommand command)
        {
            var hemocentro = hemocentroRepository.ObterPorId(command.IdHemocentro);
            var usuario = usuarioRepository.ObterUsuarioPorCPF(command.CPF);
            var tipoSanguineo = tipoSanguineoRepository.ObterPorId(command.IdTipoSanguineo);
            var feedSolicitacao = feedSolicitacaoRepository.ObterPorId(command.Id);

            command.Validate();
            if (command.Invalid)
            {
                return new GenericCommandResult(false, "Ops, parece seu cadastro está inválido.", command.Notifications);
            }
            if (!usuarioRepository.VerificarExistenciaCPF(command.CPF))
            {
                command.AddNotification(new Notification("CPF", "Usuário não cadastrado na plataforma!"));
                return new GenericCommandResult(false, "Ops, parece seu cadastro está inválido.", command.Notifications);
            }
            if (!hemocentroRepository.VerificarExistenciaCNPJ(hemocentro.CNPJ))
            {
                command.AddNotification(new Notification("CNPJ", "Hemocentro não cadastrado na plataforma!"));
                return new GenericCommandResult(false, "Ops, parece seu cadastro está inválido.", command.Notifications);
            }
            if (feedSolicitacao == null)
            {
                command.AddNotification(new Notification("Feed Solicitação", "Feed Solicitação não cadastrada na plataforma!"));
                return new GenericCommandResult(false, "Ops, parece seu cadastro está inválido.", command.Notifications);
            }

            feedSolicitacao.AlterarFeedSolicitacao(command.Descricao, command.IdTipoSanguineo, command.IdHemocentro);
            feedSolicitacao.SetarDataAlteracao(DateTime.Now);
            feedSolicitacaoRepository.Alterar(feedSolicitacao);
            var novoFeedSolicitacao = feedSolicitacaoRepository.ObterFeedSolicitacaoPorId(command.Id);

            return new GenericCommandResult(true, "Feed de solicitação alterado!", novoFeedSolicitacao);
        }

        public ICommandResult Handle(DeletarFeedSolicitacaoCommand command)
        {
            feedSolicitacaoRepository.Remover(command.Id);

            return new GenericCommandResult(true, "Feed de solicitacao removido!");
        }
    }
}
