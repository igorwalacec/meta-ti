using AutoMapper;
using AutoMapper.QueryableExtensions;
using Meta.TI.Application.Interfaces;
using Meta.TI.Application.ViewModels;
using Meta.TI.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Meta.TI.Application.Services
{
    public class EstadoService : IEstadoService
    {
        private readonly IMapper mapper;
        private readonly IEstadoRepository estadoRepository;
        public EstadoService(IMapper _mapper, IEstadoRepository _estadoRepository)
        {
            mapper = _mapper;
            estadoRepository = _estadoRepository;
        }
        public IEnumerable<EstadoViewModel> ObterEstados()
        {
            return estadoRepository.ObterTodos().ProjectTo<EstadoViewModel>(mapper.ConfigurationProvider);
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
