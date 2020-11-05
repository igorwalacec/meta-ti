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
            ConsultarFeedSolicitacaoCommand comando = new ConsultarFeedSolicitacaoCommand();
            comando.DataAtual = DateTime.Now;

            return Response(feedSolicitacaoApp.ObterTodosFeedSolicitacao(comando));
        }

        [HttpGet("obter-por-hemocentro")]
        public IActionResult ObterFeedSolicitacaoPorHemocentro()
        {
            var idHemocentro = Guid.Parse(User.Claims.Where(c => c.Type == ClaimTypes.PrimaryGroupSid)
                   .Select(c => c.Value).SingleOrDefault());

            ConsultarFeedSolicitacaoPorHemocentroCommand comando = new ConsultarFeedSolicitacaoPorHemocentroCommand();
            comando.IdHemocentro = idHemocentro;
            comando.DataAtual = DateTime.Now;

            return Response(feedSolicitacaoApp.ObterFeedSolicitacaoPorHemocentro(comando));
        }

        [HttpPost("obter-por-usuario")]
        public IActionResult ObterFeedSolicitacaoPorUsuario([FromBody] ObterFeedSolicitacaoPorIdUsuarioCommand comando)
        {
            return Response(feedSolicitacaoApp.ObterFeedSolicitacaoPorUsuario(comando));
        }

        [HttpPost("criar")]
        public IActionResult CriacaoFeedSolicitacao([FromBody] CriacaoFeedSolicitacaoCommand comando)
        {
            return Response(feedSolicitacaoApp.CriacaoFeedSolicitacao(comando));
        }

        [HttpPut("alterar")]
        public IActionResult AlterarFeedSolicitacao([FromBody] AlterarFeedSolicitacaoCommand comando)
        {
            return Response(feedSolicitacaoApp.AlterarFeedSolicitacao(comando));
        }

        [HttpDelete("deletar")]
        public IActionResult DeletarFeedSolicitacao([FromBody] DeletarFeedSolicitacaoCommand comando)
        {
            return Response(feedSolicitacaoApp.DeletarFeedSolicitacao(comando));
        }
    }
}
