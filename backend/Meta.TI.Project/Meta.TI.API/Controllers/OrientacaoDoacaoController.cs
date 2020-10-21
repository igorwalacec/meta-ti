using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Meta.TI.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Meta.TI.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrientacaoDoacaoController : ApiController
    {
        private readonly IOrientacaoDoacaoApp orientacaoDoacaoApp;
        public OrientacaoDoacaoController(IOrientacaoDoacaoApp _orientacaoDoacaoApp)
        {
            orientacaoDoacaoApp = _orientacaoDoacaoApp;
        }

        [HttpGet]
        [Route("obter-orientacao")]
        [Authorize(Roles = "doador")]
        public IActionResult ObterOrientacoesDoacao()
        {
            return Response(orientacaoDoacaoApp.ObterOrientacoesDoacao());
        }
    }
}
