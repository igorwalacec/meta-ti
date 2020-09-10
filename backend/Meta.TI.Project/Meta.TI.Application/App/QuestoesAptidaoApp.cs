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
    public class QuestoesAptidaoApp : IQuestoesAptidaoApp
    {
        private readonly IMapper mapper;
        private readonly IQuestoesAptidaoRepository questoesAptidaoRepository;
        public QuestoesAptidaoApp(IMapper _mapper, IQuestoesAptidaoRepository _questoesAptidaoRepository)
        {
            mapper = _mapper;
            questoesAptidaoRepository = _questoesAptidaoRepository;
        }        

        public GenericCommandResult ObterQuestoesAptidao()
        {
            return new GenericCommandResult(true, questoesAptidaoRepository.ObterTodos().ProjectTo<QuestoesAptidaoViewModel>(mapper.ConfigurationProvider));
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
