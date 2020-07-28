using System;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Meta.TI.Application.Interfaces;
using Meta.TI.Application.ViewModels;
using Meta.TI.Domain.Commands;
using Meta.TI.Domain.Interfaces;

namespace Meta.TI.Application.App
{
    public class TipoSanguineoApp : ITipoSanguineoApp
    {
        private readonly IMapper mapper;
        private readonly ITipoSanguineoRepository tipoSanguineoRepository;
        public TipoSanguineoApp(ITipoSanguineoRepository _tipoSanguineoRepository, IMapper _mapper)
        {
            tipoSanguineoRepository = _tipoSanguineoRepository;
            mapper = _mapper;
        }
        public GenericCommandResult ObterTiposSanguineos()
        {
            var tiposSanguineos = tipoSanguineoRepository.ObterTodos().ProjectTo<TipoSanguineoViewModel>(mapper.ConfigurationProvider);

            return new GenericCommandResult(true, tiposSanguineos);
        }
    }
}
