using AutoMapper;
using AutoMapper.QueryableExtensions;
using Meta.TI.Application.Interfaces;
using Meta.TI.Application.ViewModels;
using Meta.TI.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Meta.TI.Application.Services
{
    public class CidadeService : ICidadeService
    {
        private readonly ICidadeRepository cidadeRepository;
        private readonly IMapper mapper;
        public CidadeService(ICidadeRepository _cidadeRepository, IMapper _mapper)
        {
            cidadeRepository = _cidadeRepository;
            mapper = _mapper;
        }
        public IEnumerable<CidadeViewModel> ObterCidadesPorEstado(int idEstado)
        {
            return cidadeRepository.ObterCidadesPorEstado(idEstado)
                .ProjectTo<CidadeViewModel>(mapper.ConfigurationProvider)
                .OrderBy(x => x.Nome);
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
