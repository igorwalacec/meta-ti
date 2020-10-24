using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Meta.TI.Application.Interfaces;
using Meta.TI.Application.ViewModels;
using Meta.TI.Domain.Interfaces;
using Meta.TI.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace Meta.TI.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CidadeController : ApiController
    {
        private readonly ICidadeApp cidadeApp;
        public CidadeController(ICidadeApp _cidadeApp)
        {
            cidadeApp = _cidadeApp;
        }
        
        [HttpGet]
        [Route("obter-cidades/{idEstado}")]
        public IActionResult ObterCidadesPorEstado([FromRoute] int idEstado)
        {
            return Response(cidadeApp.ObterCidadesPorEstado(idEstado));
        }
    }
}
