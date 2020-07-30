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
    public class TipoSanguineoController : ApiController
    {
        private readonly ITipoSanguineoApp tipoSanguineoApp;
        public TipoSanguineoController(ITipoSanguineoApp _tipoSanguineoApp)
        {
            tipoSanguineoApp = _tipoSanguineoApp;
        }

        [HttpGet]
        public IActionResult ObterTiposSanguineo()
        {
            return Response(tipoSanguineoApp.ObterTiposSanguineos());
        }

        [Authorize]
        [HttpPut("/{idTipoSanguineo}")]
        public IActionResult AlterarTipoSanguineoUsuario([FromRoute] int idTipoSanguineo)
        {
            var idUsuario = Guid.Parse(User.Claims.Where(c => c.Type == ClaimTypes.PrimarySid)
                   .Select(c => c.Value).SingleOrDefault());
            AlterarTipoSanguineoCommand comando = new AlterarTipoSanguineoCommand();
            comando.IdTipoSanguineo = idTipoSanguineo;
            comando.IdUsuario = idUsuario;

            var result = tipoSanguineoApp.AlterarTipoSanguineo(comando);

            return Response(result);
        }
    }
}
