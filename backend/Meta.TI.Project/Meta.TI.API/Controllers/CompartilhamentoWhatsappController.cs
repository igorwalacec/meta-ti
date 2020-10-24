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
    public class CompartilhamentoWhatsappController : ApiController
    {
        private readonly ICompartilhamentoWhatsappApp compartilhamentoWhatsappApp;

        public CompartilhamentoWhatsappController(ICompartilhamentoWhatsappApp _compartilhamentoWhatsappApp)
        {
            compartilhamentoWhatsappApp = _compartilhamentoWhatsappApp;
        }

        [HttpGet("convite")]
        public IActionResult MontarConvite([FromBody] CompartilhamentoWhatsappCommand comando)
        {
            var idUsuario = Guid.Parse(User.Claims.Where(c => c.Type == ClaimTypes.PrimaryGroupSid)
                  .Select(c => c.Value).SingleOrDefault());

            comando.IdUsuario = idUsuario;

            return Response(compartilhamentoWhatsappApp.MontarConvite(comando));
        }
    }
}
