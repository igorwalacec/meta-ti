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
    public class DadosAptidaoHandler : Notifiable,
                            IHandler<RespostaAptidaoCommand>
    {
        private readonly string secret;
        private readonly string expirationDate;
        private readonly IConfiguration configuration;
        private readonly IQuestoesAptidaoRepository questoesAptidaoRepository;
        private readonly IResultadoAptidaoRepository resultadoAptidaoRepository;
        private readonly IRespostaAptidaoRepository respostaAptidaoRepository;
        private readonly IHistoricoAptidaoRepository historicoAptidaoRepository;

        public DadosAptidaoHandler(IConfiguration _configuration,
            IQuestoesAptidaoRepository _questoesAptidaoRepository,
            IResultadoAptidaoRepository _resultadoAptidaoRepository,
            IRespostaAptidaoRepository _respostaAptidaoRepository,
            IHistoricoAptidaoRepository _historicoAptidaoRepository)
        {
            configuration = _configuration;

            secret = configuration.GetSection("JwtConfig")
                .GetSection("secret").Value;

            expirationDate = configuration.GetSection("JwtConfig")
                .GetSection("expirationInMinutes").Value;

            questoesAptidaoRepository = _questoesAptidaoRepository;

            resultadoAptidaoRepository = _resultadoAptidaoRepository;

            respostaAptidaoRepository = _respostaAptidaoRepository;

            historicoAptidaoRepository = _historicoAptidaoRepository;
        }

        public ICommandResult Handle(RespostaAptidaoCommand command)
        {
            command.Validate();
            if (command.Invalid)
            {
                return new GenericCommandResult(false, "Ops, parece que sua resposta está inválida.", command.Notifications);
            }

            var questoes = questoesAptidaoRepository.ObterTodos();

            foreach (var item in command.RespostasAptidao)
            {
                var questoesAptidao = questoes.Where(x => x.Id == item.IdResposta).FirstOrDefault();

                var calculo = questoesAptidao.CalcularData();

                var dados = new DadosAptidaoDto
                {
                    DataResultado = DateTime.Now,
                    IdResposta = item.IdResposta,
                    Resposta = item.Resposta,                    
                    DataProximaDoacao = calculo.DataProximaDoacao,
                    DiasAfastados = calculo.NumeroDiasAfastado,
                    IdStatus = questoesAptidao.NumeroDiasAfastado > 0 ? 2 : 1
                };

                var resultadoAptidao = new ResultadoAptidao(
                    dados.DataResultado,
                    dados.DataProximaDoacao,
                    dados.DiasAfastados,
                    dados.IdStatus
                );

                resultadoAptidaoRepository.Adicionar(resultadoAptidao);

                var respostaAptidao = new RespostasAptidao(
                    item.IdResposta,
                    resultadoAptidao.Id,
                    item.Resposta
                );

                respostaAptidaoRepository.Adicionar(respostaAptidao);

                var historicoAptidao = new HistoricoAptidao(
                    command.IdUsuario,
                    resultadoAptidao.Id
                );

                historicoAptidaoRepository.Adicionar(historicoAptidao);     
            }

            return new GenericCommandResult(true, "Respostas cadastradas com sucesso!", null);
        }
    }
}
