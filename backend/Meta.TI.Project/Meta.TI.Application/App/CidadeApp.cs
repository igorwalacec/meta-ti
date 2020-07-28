using AutoMapper;
using AutoMapper.QueryableExtensions;
using Meta.TI.Application.Interfaces;
using Meta.TI.Application.ViewModels;
using Meta.TI.Domain.Commands;
using Meta.TI.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Meta.TI.Application.App
{
    public class CidadeApp : ICidadeApp
    {
        private readonly ICidadeRepository cidadeRepository;
        private readonly IMapper mapper;
        public CidadeApp(ICidadeRepository _cidadeRepository, IMapper _mapper)
        {
            cidadeRepository = _cidadeRepository;
            mapper = _mapper;
        }
        public GenericCommandResult ObterCidadesPorEstado(int idEstado)
        {
            return new GenericCommandResult(true, cidadeRepository.ObterCidadesPorEstado(idEstado)
                .ProjectTo<CidadeViewModel>(mapper.ConfigurationProvider)
                .OrderBy(x => x.Nome));
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
