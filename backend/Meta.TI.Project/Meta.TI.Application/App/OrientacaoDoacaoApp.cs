using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Meta.TI.Application.Interfaces;
using Meta.TI.Application.ViewModels;
using Meta.TI.Domain.Commands;
using Meta.TI.Domain.Interfaces;

namespace Meta.TI.Application.App
{
    public class OrientacaoDoacaoApp : IOrientacaoDoacaoApp
    {
        private readonly IMapper mapper;
        private readonly IOrientacaoDoacaoRepository orientacaoDoacaoRepository;

        public OrientacaoDoacaoApp(IMapper _mapper, IOrientacaoDoacaoRepository _orientacaoDoacaoRepository)
        {
            mapper = _mapper;
            orientacaoDoacaoRepository = _orientacaoDoacaoRepository;
        }

        public GenericCommandResult ObterOrientacoesDoacao()
        {
            return new GenericCommandResult(true, orientacaoDoacaoRepository.ObterTodos().ProjectTo<OrientacaoDoacaoViewModel>(mapper.ConfigurationProvider));
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }        
    }
}
