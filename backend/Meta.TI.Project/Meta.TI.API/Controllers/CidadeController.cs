using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Meta.TI.Application.Interfaces;
using Meta.TI.Application.ViewModels;
using Meta.TI.Domain.Interfaces;
using Meta.TI.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace Meta.TI.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CidadeController : ControllerBase
    {
        private readonly ICidadeService cidadeService;
        public CidadeController(ICidadeService _cidadeService)
        {
            cidadeService = _cidadeService;
        }

        [HttpGet]
        [Route("obter-cidades/{idEstado}")]
        public IEnumerable<CidadeViewModel> ObterCidadesPorEstado([FromRoute] int idEstado)
        {
            return cidadeService.ObterCidadesPorEstado(idEstado);
        }
    }
}