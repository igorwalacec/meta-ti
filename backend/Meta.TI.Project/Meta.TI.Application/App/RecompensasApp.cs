using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Meta.TI.Application.Interfaces;
using Meta.TI.Application.ViewModels;
using Meta.TI.Domain.Commands;
using Meta.TI.Domain.Handlers;
using Meta.TI.Domain.Interfaces;

namespace Meta.TI.Application.App
{
    public class RecompensasApp : IRecompensasApp
    {
        private readonly IMapper mapper;
        private readonly RecompensasHandler recompensasHandler;
        private readonly ILevelRepository levelRepository;
        private readonly IRecompensasRepository recompensasRepository;
        private readonly IPatrocinadorRepository patrocinadorRepository;

        public RecompensasApp(IMapper _mapper,
            ILevelRepository _levelRepository,
            IRecompensasRepository _recompensasRepository,
            IPatrocinadorRepository _patrocinadorRepository,
            RecompensasHandler _recompensasHandler)
        {
            mapper = _mapper;
            levelRepository = _levelRepository;
            recompensasRepository = _recompensasRepository;
            patrocinadorRepository = _patrocinadorRepository;
            recompensasHandler = _recompensasHandler;
        }

        public GenericCommandResult CalcularLevelDoador(CalcularLevelDoadorCommand command)
        {
            var result = (GenericCommandResult)recompensasHandler.Handle(command);

            return result;
        }

        public GenericCommandResult AdicionarLevel(AdicionarLevelCommand comando)
        {
            var result = (GenericCommandResult)recompensasHandler.Handle(comando);

            return result;
        }

        public GenericCommandResult AdicionarPatrocinador(AdicionarPatrocinadorCommand comando)
        {
            var result = (GenericCommandResult)recompensasHandler.Handle(comando);

            return result;
        }

        public GenericCommandResult AdicionarRecompensas(AdicionarRecompensasCommand comando)
        {
            var result = (GenericCommandResult)recompensasHandler.Handle(comando);

            return result;
        }

        public GenericCommandResult DesativarLevelPorId(DesativarLevelPorIdCommand command)
        {
            var result = (GenericCommandResult)recompensasHandler.Handle(command);

            return result;
        }

        public GenericCommandResult DesativarPatrocinadorPorId(DesativarPatrocinadorPorIdCommand command)
        {
            var result = (GenericCommandResult)recompensasHandler.Handle(command);

            return result;
        }

        public GenericCommandResult DesativarRecompensasPorId(DesativarRecompensasPorIdCommand command)
        {
            var result = (GenericCommandResult)recompensasHandler.Handle(command);

            return result;
        }

        public GenericCommandResult ListarLevel()
        {
            return new GenericCommandResult(true, levelRepository.ObterTodos().Where(x => x.Ativo == true).ProjectTo<LevelViewModel>(mapper.ConfigurationProvider));
        }

        public GenericCommandResult ListarPatrocinador()
        {
            return new GenericCommandResult(true, patrocinadorRepository.ObterTodos().Where(x => x.Ativo == true).ProjectTo<PatrocinadorViewModel>(mapper.ConfigurationProvider));
        }

        public GenericCommandResult ListarRecompensas()
        {
            return new GenericCommandResult(true, recompensasRepository.ObterTodos().Where(x => x.Ativo == true).ProjectTo<RecompensasViewModel>(mapper.ConfigurationProvider));
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
