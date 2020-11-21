using System;
using System.Linq;
using System.Security.Claims;
using Meta.TI.Application.Interfaces;
using Meta.TI.Domain.Commands;
using Microsoft.AspNetCore.Mvc;

namespace Meta.TI.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AgendamentoController : ApiController
    {
        private readonly IAgendamentoApp agendamentoApp;

        public AgendamentoController(IAgendamentoApp _agendamentoApp)
        {
            agendamentoApp = _agendamentoApp;
        }

        [HttpGet("{idAgendamento}")]
        public IActionResult ConsultarAgendamentoPorId([FromRoute] Guid idAgendamento)
        {
            ConsultarAgendamentoPorIdCommand comando = new ConsultarAgendamentoPorIdCommand();
            comando.Id = idAgendamento;

            return Response(agendamentoApp.ConsultarAgendamentoPorId(comando));
        }

        [HttpGet("obter-por-usuario")]
        public IActionResult ConsultarAgendamentoPorIdUsuario()
        {
            var idUsuario = Guid.Parse(User.Claims.Where(c => c.Type == ClaimTypes.PrimarySid)
                   .Select(c => c.Value).SingleOrDefault());

            ConsultarAgendamentoPorIdUsuarioCommand comando = new ConsultarAgendamentoPorIdUsuarioCommand();
            comando.IdUsuario = idUsuario;

            return Response(agendamentoApp.ConsultarAgendamentoPorIdUsuario(comando));
        }

        [HttpPost("criar")]
        public IActionResult CriacaoAgendamento([FromBody] CriacaoAgendamentoCommand comando)
        {
            return Response(agendamentoApp.CriacaoAgendamento(comando));
        }

        [HttpPut("alterar")]
        public IActionResult AlterarAgendamento([FromBody] AlterarAgendamentoCommand comando)
        {       
            return Response(agendamentoApp.AlterarAgendamento(comando));
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeletarAgendamento([FromRoute] DeletarAgendamentoCommand comando)
        {
            return Response(agendamentoApp.DeletarAgendamento(comando));
        }
    }
}
