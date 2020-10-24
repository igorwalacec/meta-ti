using System;
using System.Linq;
using System.Security.Claims;
using Meta.TI.Application.Interfaces;
using Meta.TI.Domain.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Meta.TI.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DoacaoController : ApiController
    {
        private readonly IDoacaoApp doacaoApp;

        public DoacaoController(IDoacaoApp _historicoDoacaoApp)
        {
            doacaoApp = _historicoDoacaoApp;
        }

        [HttpPost]
        [Route("cadastrar")]
        [Authorize(Roles = "doador")]
        public IActionResult CadastrarDoacao([FromBody] CadastrarNovaDoacaoCommand doacao)
        {
            var idUsuario = Guid.Parse(User.Claims.Where(c => c.Type == ClaimTypes.PrimarySid)
                   .Select(c => c.Value).SingleOrDefault());

            doacao.IdUsuario = idUsuario;

            return Response(doacaoApp.CadastrarNovaDoacao(doacao));
        }

        [HttpPost]
        [Route("obter-historico")]
        [Authorize(Roles = "doador")]
        public IActionResult ObterHistoricoDoacao()
        {
            var idUsuario = Guid.Parse(User.Claims.Where(c => c.Type == ClaimTypes.PrimarySid)
                   .Select(c => c.Value).SingleOrDefault());

            return Response(doacaoApp.ObterHistoricoDoacao(idUsuario));
        }

        [HttpGet]
        [Route("obter-orientacao")]
        [Authorize(Roles = "doador")]
        public IActionResult ObterOrientacoesDoacao()
        {
            return Response(doacaoApp.ObterOrientacoesDoacao());
        }

        [HttpGet]
        [Route("obter-status")]
        [Authorize(Roles = "doador")]
        public IActionResult BuscarStatusDoacao()
        {
            var idUsuario = Guid.Parse(User.Claims.Where(c => c.Type == ClaimTypes.PrimarySid)
                   .Select(c => c.Value).SingleOrDefault());

            StatusDoacaoCommand statusDoacaoCommand = new StatusDoacaoCommand();
            statusDoacaoCommand.IdUsuario = idUsuario;

            var retorno = doacaoApp.BuscarStatusDoacao(statusDoacaoCommand);

            return Response(retorno);
        }
    }
}
