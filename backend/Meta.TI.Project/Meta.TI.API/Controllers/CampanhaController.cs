using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Meta.TI.Application.Interfaces;
using Meta.TI.Domain.Commands;
using Microsoft.AspNetCore.Mvc;

namespace Meta.TI.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CampanhaController : ApiController
    {
        private readonly ICampanhaApp campanhaApp;

        public CampanhaController(ICampanhaApp _campanhaApp)
        {
            campanhaApp = _campanhaApp;
        }

        [HttpGet]
        public IActionResult ObterTodasCampanha()
        {
            return Response(campanhaApp.ObterTodasCampanhas());
        }

        [HttpGet("filtrar-campanha")]
        public IActionResult ObterCampanhaPorHemocentro()
        {
            var idHemocentro = Guid.Parse(User.Claims.Where(c => c.Type == ClaimTypes.PrimaryGroupSid)
                   .Select(c => c.Value).SingleOrDefault());

            return Response(campanhaApp.ObterCampanhaPorHemocentro(idHemocentro));
        }

        [HttpPost("criar")]
        public IActionResult CriacaoCampanha(CriacaoCampanhaCommand comando)
        {
            return Response(campanhaApp.CriacaoCampanha(comando));
        }

        [HttpPut("alterar")]
        public IActionResult AlterarCampanha(AlterarCampanhaCommand comando)
        {
            return Response(campanhaApp.AlterarCampanha(comando));
        }

        [HttpDelete("/{idFeedSolicitacao}")]
        public IActionResult DeletarCampanha([FromRoute] int idCampanha)
        {
            return Response(campanhaApp.DeletarCampanha(idCampanha));
        }
    }
}
