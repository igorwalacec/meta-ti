using AutoMapper;
using AutoMapper.QueryableExtensions;
using Meta.TI.Application.Interfaces;
using Meta.TI.Application.ViewModels;
using Meta.TI.Domain.Commands;
using Meta.TI.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Meta.TI.Application.App
{
    public class EstadoApp : IEstadoApp
    {
        private readonly IMapper mapper;
        private readonly IEstadoRepository estadoRepository;
        public EstadoApp(IMapper _mapper, IEstadoRepository _estadoRepository)
        {
            mapper = _mapper;
            estadoRepository = _estadoRepository;
        }
        public GenericCommandResult ObterEstados()
        {
            return new GenericCommandResult(true , estadoRepository.ObterTodos().ProjectTo<EstadoViewModel>(mapper.ConfigurationProvider));
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
