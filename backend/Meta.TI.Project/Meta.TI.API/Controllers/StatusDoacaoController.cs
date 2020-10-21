using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Meta.TI.Application.Interfaces;
using Meta.TI.Domain.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Meta.TI.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StatusDoacaoController : ApiController
    {
        private readonly IStatusDoacaoApp statusDoacaoApp;
        private readonly StatusDoacaoCommand statusDoacaoCommand;
        public StatusDoacaoController(IStatusDoacaoApp _statusDoacaoApp, StatusDoacaoCommand _statusDoacaoCommand)
        {
            statusDoacaoApp = _statusDoacaoApp;
            statusDoacaoCommand = _statusDoacaoCommand;
        }

        [HttpGet]
        [Route("buscar-status-doacao")]
        [Authorize(Roles = "doador")]
        public IActionResult BuscarStatusDoacao()
        {
            var idUsuario = Guid.Parse(User.Claims.Where(c => c.Type == ClaimTypes.PrimarySid)
                   .Select(c => c.Value).SingleOrDefault());

            statusDoacaoCommand.IdUsuario = idUsuario;

            var retorno = statusDoacaoApp.BuscarStatusDoacao(statusDoacaoCommand);

            return Response(retorno);
        }
    }
}
