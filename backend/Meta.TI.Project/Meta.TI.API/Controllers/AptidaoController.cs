using System;
using System.Collections.Generic;
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
    public class AptidaoController : ApiController
    {
        private readonly IAptidaoApp aptidaoApp;

        public AptidaoController(IAptidaoApp _questoesAptidaoApp)
        {
            aptidaoApp = _questoesAptidaoApp;            
        }

        [HttpGet]
        [Route("obter-questoes")]
        [Authorize(Roles = "doador")]
        public IActionResult ObterQuestoesAptidao()
        {
            return Response(aptidaoApp.ObterQuestoesAptidao());
        }

        [HttpPost]
        [Route("cadastrar-respostas")]
        [Authorize(Roles = "doador")]
        public IActionResult CadastrarRespostasAptidao(RespostaAptidaoCommand respostasAptidao)
        {
            var idUsuario = Guid.Parse(User.Claims.Where(c => c.Type == ClaimTypes.PrimarySid)
                .Select(c => c.Value).SingleOrDefault());

            respostasAptidao.IdUsuario = idUsuario;

            var retorno = aptidaoApp.CadastrarRespostasAptidao(respostasAptidao);

            return Response(retorno);
        }

        [HttpGet]
        [Route("calcular-dayoff")]
        [Authorize(Roles = "doador")]
        public IActionResult CalcularDayOff()
        {
            var idUsuario = Guid.Parse(User.Claims.Where(c => c.Type == ClaimTypes.PrimarySid)
                   .Select(c => c.Value).SingleOrDefault());

            StatusDoacaoCommand statusDoacaoCommand = new StatusDoacaoCommand();
            statusDoacaoCommand.IdUsuario = idUsuario;

            var retorno = aptidaoApp.CalcularDayOff(statusDoacaoCommand);

            return Response(retorno);
        }
    }
}
