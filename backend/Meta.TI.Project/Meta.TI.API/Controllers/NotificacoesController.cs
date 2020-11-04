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
    public class NotificacoesController : ApiController
    {
        private readonly INotificacoesApp notificacoesApp;

        public NotificacoesController(INotificacoesApp _notificacoesApp)
        {
            notificacoesApp = _notificacoesApp;
        }

        [HttpGet("obter-por-usuario")]
        [AllowAnonymous]
        public IActionResult ConsultarNotificacoesPorIdUsuario()
        {
            var idUsuario = Guid.Parse(User.Claims.Where(c => c.Type == ClaimTypes.PrimarySid)
                   .Select(c => c.Value).SingleOrDefault());

            ConsultarNotificacoesPorIdUsuarioCommand comando = new ConsultarNotificacoesPorIdUsuarioCommand();
            comando.IdUsuario = idUsuario;

            return Response(notificacoesApp.ConsultarNotificacoesPorIdUsuario(comando));
        }
    }
}
