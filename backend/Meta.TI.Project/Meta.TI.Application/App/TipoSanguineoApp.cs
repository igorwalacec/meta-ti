using System;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Meta.TI.Application.Interfaces;
using Meta.TI.Application.ViewModels;
using Meta.TI.Domain.Commands;
using Meta.TI.Domain.Handlers;
using Meta.TI.Domain.Interfaces;

namespace Meta.TI.Application.App
{
    public class TipoSanguineoApp : ITipoSanguineoApp
    {
        private readonly IMapper mapper;
        private readonly ITipoSanguineoRepository tipoSanguineoRepository;
        private readonly UsuarioHandler handler;
        public TipoSanguineoApp(ITipoSanguineoRepository _tipoSanguineoRepository, IMapper _mapper, UsuarioHandler _handler)
        {
            tipoSanguineoRepository = _tipoSanguineoRepository;
            mapper = _mapper;
            handler = _handler;
        }

        public GenericCommandResult AlterarTipoSanguineo(AlterarTipoSanguineoCommand comando)
        {
            var result = (GenericCommandResult)handler.Handle(comando);

            if (result.Sucess)
            {
                result.Data = mapper.Map<UsuarioViewModel>(result.Data);
            }
            return result;
        }

        public GenericCommandResult ObterTiposSanguineos()
        {
            var tiposSanguineos = tipoSanguineoRepository.ObterTodos().ProjectTo<TipoSanguineoViewModel>(mapper.ConfigurationProvider);

            return new GenericCommandResult(true, tiposSanguineos);
        }
    }
}
