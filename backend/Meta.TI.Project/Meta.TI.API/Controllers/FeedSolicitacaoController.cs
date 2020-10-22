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
    public class FeedSolicitacaoController : ApiController
    {
        private readonly IFeedSolicitacaoApp feedSolicitacaoApp;

        public FeedSolicitacaoController(IFeedSolicitacaoApp _feedSolicitacaoApp)
        {
            feedSolicitacaoApp = _feedSolicitacaoApp;
        }

        [HttpGet]
        public IActionResult ObterTodosFeedSolicitacao()
        {
            return Response(feedSolicitacaoApp.ObterTodosFeedSolicitacao());
        }

        [HttpGet("filtrar-hemocentro")]
        public IActionResult ObterFeedSolicitacaoPorHemocentro()
        {
            var idHemocentro = Guid.Parse(User.Claims.Where(c => c.Type == ClaimTypes.PrimaryGroupSid)
                   .Select(c => c.Value).SingleOrDefault());

            return Response(feedSolicitacaoApp.ObterFeedSolicitacaoPorHemocentro(idHemocentro));
        }

        [HttpPost("criar")]
        public IActionResult CriacaoFeedSolicitacao(CriacaoFeedSolicitacaoCommand comando)
        {
            return Response(feedSolicitacaoApp.CriacaoFeedSolicitacao(comando));
        }

        [HttpPut("alterar")]
        public IActionResult AlterarFeedSolicitacao(AlterarFeedSolicitacaoCommand comando)
        {
            return Response(feedSolicitacaoApp.AlterarFeedSolicitacao(comando));
        }

        [HttpDelete("/{idFeedSolicitacao}")]
        public IActionResult DeletarFeedSolicitacao([FromRoute] int idFeedSolicitacao)
        {
            return Response(feedSolicitacaoApp.DeletarFeedSolicitacao(idFeedSolicitacao));
        }
    }
}
