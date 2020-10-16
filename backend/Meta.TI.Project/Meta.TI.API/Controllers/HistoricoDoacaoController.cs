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
    public class HistoricoDoacaoController : ApiController
    {
        private readonly IHistoricoDoacaoApp historicoDoacaoApp;

        public HistoricoDoacaoController(IHistoricoDoacaoApp _historicoDoacaoApp)
        {
            historicoDoacaoApp = _historicoDoacaoApp;
        }

        [HttpPost]
        [Route("cadastrar-doacao")]
        [Authorize(Roles = "doador")]
        public IActionResult CadastrarDoacao([FromBody] CadastrarNovaDoacaoCommand doacao)
        {
            var idUsuario = Guid.Parse(User.Claims.Where(c => c.Type == ClaimTypes.PrimarySid)
                   .Select(c => c.Value).SingleOrDefault());

            doacao.IdUsuario = idUsuario;

            return Response(historicoDoacaoApp.CadastrarNovaDoacao(doacao));
        }
    }
}
