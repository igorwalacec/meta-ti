using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Meta.TI.Application.Interfaces;
using Meta.TI.Application.ViewModels;
using Meta.TI.Domain.Commands;
using Meta.TI.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Meta.TI.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TelefoneController : ApiController
    {
        private readonly ITelefoneApp telefoneApp;

        public TelefoneController(ITelefoneApp _telefoneApp)
        {
            telefoneApp = _telefoneApp;
        }

        [HttpPut("atualizar")]
        public IActionResult AtualizarTelefones([FromBody] AlterarTelefoneHemocentroCommand comando)
        {
            var idHemocentro = Guid.Parse(User.Claims.Where(c => c.Type == ClaimTypes.PrimaryGroupSid)
                   .Select(c => c.Value).SingleOrDefault());

            comando.DadosTelefone.ForEach(x => x.IdHemocentro = idHemocentro);

            return Response(telefoneApp.AlterarTelefoneHemocentro(comando));
        }
    }
}
