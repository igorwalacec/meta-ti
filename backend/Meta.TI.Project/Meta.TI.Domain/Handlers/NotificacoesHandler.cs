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
    public class NotificacoesHandler : Notifiable,
                                  IHandler<ConsultarNotificacoesPorIdUsuarioCommand>
    {
        private readonly INotificacoesRepository notificacoesRepository;
        private readonly IUsuarioRepository usuarioRepository;
        private readonly ICampanhaRepository campanhaRepository;
        private readonly IEstoqueSanguineoRepository estoqueSanguineoRepository;
        private readonly IFeedSolicitacaoRepository feedSolicitacaoRepository;

        public NotificacoesHandler(INotificacoesRepository _notificacoesRepository,
                                   IUsuarioRepository _usuarioRepository,
                                   ICampanhaRepository _campanhaRepository,
                                   IEstoqueSanguineoRepository _estoqueSanguineoRepository,
                                   IFeedSolicitacaoRepository _feedSolicitacaoRepository)
        {
            notificacoesRepository = _notificacoesRepository;
            usuarioRepository = _usuarioRepository;
            campanhaRepository = _campanhaRepository;
            estoqueSanguineoRepository = _estoqueSanguineoRepository;
            feedSolicitacaoRepository = _feedSolicitacaoRepository;
        }

        public ICommandResult Handle(ConsultarNotificacoesPorIdUsuarioCommand command)
        {

            var usuario = usuarioRepository.ObterUsuarioPorId(command.IdUsuario);
            notificacoesRepository.RemoverNotificacoesPorUsuario(command.IdUsuario);


            Notificacoes novaNotificacao = new Notificacoes();
            var campanhas = campanhaRepository.ExtracaoCampanhasParaNotificacoes(usuario.Endereco.IdCidade);
            var estoquesSanguineo = estoqueSanguineoRepository.ExtracaoEstoqueSanguineoParaNotificacoes(usuario.Endereco.IdCidade, usuario.IdTipoSanguineo);
            var feedSolicitacao = feedSolicitacaoRepository.ExtracaoFeedSolicitacaoParaNotificacoes(usuario.Id, usuario.Endereco.IdCidade, usuario.IdTipoSanguineo);

            foreach (var item in campanhas)
            {
                novaNotificacao.GerarId();
                novaNotificacao.IdUsuario = usuario.Id;
                novaNotificacao.Titulo = "Nova campanha disponível!";
                novaNotificacao.Descricao = "Uma nova campanha foi criada no hemocentro " + item.Hemocentro.Nome
                                            + ", colabore para salvarmos mais vidas! estamos juntos nessa luta!";
                novaNotificacao.SetarDataCriacao(DateTime.Now);
                novaNotificacao.IdHemocentro = item.IdHemocentro;

                notificacoesRepository.Adicionar(novaNotificacao);
            }

            foreach(var item in estoquesSanguineo)
            { 
                novaNotificacao.GerarId();
                novaNotificacao.IdUsuario = usuario.Id;
                novaNotificacao.Titulo = "Ajude o Hemocentro!";
                novaNotificacao.Descricao = "O hemocentro " + item.Hemocentro.Nome + " próximo a você precisa está do tipo de sanguineo "
                                            + item.TipoSanguineo.Nome + " em seus estoques, ajude ele salvando vidas! estamos juntos nessa luta!";
                novaNotificacao.SetarDataCriacao(DateTime.Now);
                novaNotificacao.IdHemocentro = item.IdHemocentro;

                notificacoesRepository.Adicionar(novaNotificacao);
            }

            foreach (var item in feedSolicitacao)
            {
                novaNotificacao.GerarId();
                novaNotificacao.IdUsuario = usuario.Id;
                novaNotificacao.Titulo = "Ajude um amigo!";
                novaNotificacao.Descricao = "Uma nova solicitação de sangue foi criada, ajude um amigo no hemocentro " + item.Hemocentro.Nome
                                            + ", ele precisa do tipo sanguineo " + item.TipoSanguineo.Nome + " ! estamos juntos nessa luta!";
                novaNotificacao.SetarDataCriacao(DateTime.Now);
                novaNotificacao.IdHemocentro = item.IdHemocentro;

                notificacoesRepository.Adicionar(novaNotificacao);
            }

            var notificacoes = notificacoesRepository.ObterNotificacoesPorUsuario(command.IdUsuario);

            return new GenericCommandResult(true, notificacoes);
        }
    }
}
