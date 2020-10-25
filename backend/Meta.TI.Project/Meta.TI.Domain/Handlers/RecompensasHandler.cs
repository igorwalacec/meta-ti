using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Flunt.Notifications;
using Meta.TI.Domain.Commands;
using Meta.TI.Domain.Commands.Contracts;
using Meta.TI.Domain.Dto;
using Meta.TI.Domain.Handlers.Contracts;
using Meta.TI.Domain.Interfaces;
using Meta.TI.Domain.Models;
using Microsoft.Extensions.Configuration;

namespace Meta.TI.Domain.Handlers
{
    public class RecompensasHandler : Notifiable,
                            IHandler<AdicionarLevelCommand>,
                            IHandler<AdicionarPatrocinadorCommand>,
                            IHandler<AdicionarRecompensasCommand>,
                            IHandler<DesativarLevelPorIdCommand>,
                            IHandler<DesativarPatrocinadorPorIdCommand>,
                            IHandler<DesativarRecompensasPorIdCommand>,
                            IHandler<CalcularLevelDoadorCommand>
    {
        private readonly IConfiguration configuration;
        private readonly ILevelRepository levelRepository;
        private readonly IPatrocinadorRepository patrocinadorRepository;
        private readonly IRecompensasRepository recompensasRepository;
        private readonly IHistoricoDoacaoRepository historicoDoacaoRepository;

        public RecompensasHandler(IConfiguration _configuration,
            ILevelRepository _levelRepository,
            IPatrocinadorRepository _patrocinadorRepository,
            IRecompensasRepository _recompensasRepository,
            IHistoricoDoacaoRepository _historicoDoacaoRepository)
        {
            configuration = _configuration;

            levelRepository = _levelRepository;

            patrocinadorRepository = _patrocinadorRepository;

            recompensasRepository = _recompensasRepository;

            historicoDoacaoRepository = _historicoDoacaoRepository;
        }

        public ICommandResult Handle(CalcularLevelDoadorCommand command)
        {
            command.Validate();
            if (command.Invalid)
            {
                return new GenericCommandResult(false, "Ops, parece que sua resposta está inválida.", command.Notifications);
            }

            var listarDoacoes = historicoDoacaoRepository.ObterTodos();


            return new GenericCommandResult(true, "Level cadastrado com sucesso!", null);
        }

        public ICommandResult Handle(AdicionarLevelCommand command)
        {
            command.Validate();
            if (command.Invalid)
            {
                return new GenericCommandResult(false, "Ops, parece que sua resposta está inválida.", command.Notifications);
            }

            var level = new Level(
                    command.Nivel,
                    command.QuantidadeDoacao,
                    command.IdRecompensa
            );

            levelRepository.Adicionar(level);

            return new GenericCommandResult(true, "Level cadastrado com sucesso!", null);
        }

        public ICommandResult Handle(AdicionarPatrocinadorCommand command)
        {
            command.Validate();
            if (command.Invalid)
            {
                return new GenericCommandResult(false, "Ops, parece que sua resposta está inválida.", command.Notifications);
            }

            var patrocinador = new Patrocinador(
                    command.NomePatrocinador
            );

            patrocinadorRepository.Adicionar(patrocinador);

            return new GenericCommandResult(true, "Patrocinador cadastrado com sucesso!", null);
        }

        public ICommandResult Handle(AdicionarRecompensasCommand command)
        {
            command.Validate();
            if (command.Invalid)
            {
                return new GenericCommandResult(false, "Ops, parece que sua resposta está inválida.", command.Notifications);
            }

            var recompensas = new Recompensas(
                    command.Descricao,
                    command.IdPatrocinador
            );

            recompensasRepository.Adicionar(recompensas);

            return new GenericCommandResult(true, "Recompensas cadastrado com sucesso!", null);
        }

        public ICommandResult Handle(DesativarLevelPorIdCommand command)
        {
            command.Validate();
            if (command.Invalid)
            {
                return new GenericCommandResult(false, "Ops, parece que sua resposta está inválida.", command.Notifications);
            }

            var level = levelRepository.ObterPorId(command.IdDesativado);
            level.AlterarAtivo(false);

            levelRepository.Alterar(level);

            return new GenericCommandResult(true, "Level desativado com sucesso!");
        }

        public ICommandResult Handle(DesativarPatrocinadorPorIdCommand command)
        {
            command.Validate();
            if (command.Invalid)
            {
                return new GenericCommandResult(false, "Ops, parece que sua resposta está inválida.", command.Notifications);
            }

            var patrocinador = patrocinadorRepository.ObterPorId(command.IdDesativado);
            patrocinador.AlterarAtivo(false);

            patrocinadorRepository.Alterar(patrocinador);

            return new GenericCommandResult(true, "Level desativado com sucesso!");
        }

        public ICommandResult Handle(DesativarRecompensasPorIdCommand command)
        {
            command.Validate();
            if (command.Invalid)
            {
                return new GenericCommandResult(false, "Ops, parece que sua resposta está inválida.", command.Notifications);
            }

            var recompensa = recompensasRepository.ObterPorId(command.IdDesativado);
            recompensa.AlterarAtivo(false);

            recompensasRepository.Alterar(recompensa);

            return new GenericCommandResult(true, "Level desativado com sucesso!");
        }        
    }
}
