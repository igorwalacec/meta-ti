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
            ConsultarCampanhaCommand comando = new ConsultarCampanhaCommand();
            comando.DataAtual = DateTime.Now;

            return Response(campanhaApp.ObterTodasCampanhas(comando));
        }

        [HttpGet("obter-campanha-por-hemocentro")]
        public IActionResult ObterCampanhaPorHemocentro()
        {
            var idHemocentro = Guid.Parse(User.Claims.Where(c => c.Type == ClaimTypes.PrimaryGroupSid)
                   .Select(c => c.Value).SingleOrDefault());

            ConsultarCampanhaPorHemocentroCommand comando = new ConsultarCampanhaPorHemocentroCommand();
            comando.IdHemocentro = idHemocentro;
            comando.DataAtual = DateTime.Now;

            return Response(campanhaApp.ObterCampanhaPorHemocentro(comando));
        }

        [HttpPost("criar")]
        public IActionResult CriacaoCampanha([FromBody] CriacaoCampanhaCommand comando)
        {
            var idHemocentro = Guid.Parse(User.Claims.Where(c => c.Type == ClaimTypes.PrimaryGroupSid)
                   .Select(c => c.Value).SingleOrDefault());

            comando.IdHemocentro = idHemocentro;
            return Response(campanhaApp.CriacaoCampanha(comando));
        }

        [HttpPut("alterar")]
        public IActionResult AlterarCampanha([FromBody] AlterarCampanhaCommand comando)
        {
            return Response(campanhaApp.AlterarCampanha(comando));
        }

        [HttpDelete("deletar")]
        public IActionResult DeletarCampanha([FromBody] DeletarCampanhaCommand comando)
        {
            return Response(campanhaApp.DeletarCampanha(comando));
        }
    }
}
