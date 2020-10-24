using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Flunt.Notifications;
using Meta.TI.Domain.Commands;
using Meta.TI.Domain.Commands.Contracts;
using Meta.TI.Domain.Handlers.Contracts;
using Meta.TI.Domain.Interfaces;
using Meta.TI.Domain.Models;

namespace Meta.TI.Domain.Handlers
{
    public class CampanhaHandler : Notifiable,
                                   IHandler<ConsultarCampanhaCommand>,
                                   IHandler<ConsultarCampanhaPorHemocentroCommand>,
                                   IHandler<CriacaoCampanhaCommand>,
                                   IHandler<AlterarCampanhaCommand>,
                                   IHandler<DeletarCampanhaCommand>
    {
        private readonly ICampanhaRepository campanhaRepository;
        private readonly IHemocentroRepository hemocentroRepository;

        public CampanhaHandler(ICampanhaRepository _campanhaRepository,
                               IHemocentroRepository _hemocentroRepository)
        {
            campanhaRepository = _campanhaRepository;
            hemocentroRepository = _hemocentroRepository;
        }

        public ICommandResult Handle(ConsultarCampanhaCommand command)
        {
            var campanhas = campanhaRepository.ObterTodasCampanhas(command.DataAtual);

            if (campanhas.Count() <= 0)
                return new GenericCommandResult(false, "Campanha não encontrada!");

            return new GenericCommandResult(true, campanhas);
        }

        public ICommandResult Handle(ConsultarCampanhaPorHemocentroCommand command)
        {
            var campanhas = campanhaRepository.ObterCampanhaPorHemocentro(command.DataAtual, command.IdHemocentro);

            if (campanhas == null)
                return new GenericCommandResult(false, "Campanha não encontrada!");

            return new GenericCommandResult(true, campanhas);
        }

        public ICommandResult Handle(CriacaoCampanhaCommand command)
        {
            var hemocentro = hemocentroRepository.ObterPorId(command.IdHemocentro);
  
            command.Validate();
            if (command.Invalid)
            {
                return new GenericCommandResult(false, "Ops, parece seu cadastro está inválido.", command.Notifications);
            }
            if (!hemocentroRepository.VerificarExistenciaCNPJ(hemocentro.CNPJ))
            {
                command.AddNotification(new Notification("CNPJ", "Hemocentro não cadastrado na plataforma!"));
                return new GenericCommandResult(false, "Ops, parece seu cadastro está inválido.", command.Notifications);
            }
           
            var campanha = new Campanha(
                command.Titulo,
                command.Descricao,
                hemocentro
            );

            campanha.SetarDataCriacao(DateTime.Now);
            campanhaRepository.Adicionar(campanha);
            var novaCampanha = campanhaRepository.ObterCampanhaCriada(command.IdHemocentro);

            return new GenericCommandResult(true, "Campanha cadastrada!", novaCampanha);
        }

        public ICommandResult Handle(AlterarCampanhaCommand command)
        {
            var hemocentro = hemocentroRepository.ObterPorId(command.IdHemocentro);

            command.Validate();
            if (command.Invalid)
            {
                return new GenericCommandResult(false, "Ops, parece seu cadastro está inválido.", command.Notifications);
            }
            if (!hemocentroRepository.VerificarExistenciaCNPJ(hemocentro.CNPJ))
            {
                command.AddNotification(new Notification("CNPJ", "Hemocentro não cadastrado na plataforma!"));
                return new GenericCommandResult(false, "Ops, parece seu cadastro está inválido.", command.Notifications);
            }

            var campanha = new Campanha(
                command.Id,
                command.Titulo,
                command.Descricao,
                hemocentro
            );

            campanha.SetarDataAlteracao(DateTime.Now);
            campanhaRepository.Alterar(campanha);
            var novaCampanha = campanhaRepository.ObterCampanhaPorId(command.Id);

            return new GenericCommandResult(true, "Campanha cadastrada!", novaCampanha);
        }

        public ICommandResult Handle(DeletarCampanhaCommand command)
        {
            campanhaRepository.Remover(command.Id);

            return new GenericCommandResult(true, "Campanha removido!");
        }
    }
}
