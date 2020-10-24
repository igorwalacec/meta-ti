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
    public class AgendamentoController : ApiController
    {
        private readonly IAgendamentoApp agendamentoApp;

        public AgendamentoController(IAgendamentoApp _agendamentoApp)
        {
            agendamentoApp = _agendamentoApp;
        }

        [HttpGet("filtrar-por-agendamento")]
        public IActionResult ConsultarAgendamentoPorId([FromBody] ConsultarAgendamentoPorIdCommand comando)
        {
            return Response(agendamentoApp.ConsultarAgendamentoPorId(comando));
        }

        [HttpGet("obter-por-usuario")]
        public IActionResult ConsultarAgendamentoPorIdUsuario()
        {
            var idUsuario = Guid.Parse(User.Claims.Where(c => c.Type == ClaimTypes.PrimaryGroupSid)
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

        [HttpDelete("deletar")]
        public IActionResult DeletarAgendamento([FromBody] DeletarAgendamentoCommand comando)
        {
            return Response(agendamentoApp.DeletarAgendamento(comando));
        }
    }
}
