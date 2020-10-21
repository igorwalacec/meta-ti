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
    public class HistoricoAptidaoController : ApiController
    {
        private readonly IHistoricoAptidaoApp historicoAptidaoApp;
        private readonly StatusDoacaoCommand statusDoacaoCommand;
        public HistoricoAptidaoController(IHistoricoAptidaoApp _historicoAptidaoApp, StatusDoacaoCommand _statusDoacaoCommand)
        {
            historicoAptidaoApp = _historicoAptidaoApp;
            statusDoacaoCommand = _statusDoacaoCommand;
        }

        [HttpGet]
        [Route("calcular-daysoff")]
        [Authorize(Roles = "doador")]
        public IActionResult CalcularDayOff()
        {
            var idUsuario = Guid.Parse(User.Claims.Where(c => c.Type == ClaimTypes.PrimarySid)
                   .Select(c => c.Value).SingleOrDefault());

            statusDoacaoCommand.IdUsuario = idUsuario;

            var retorno = historicoAptidaoApp.CalcularDayOff(statusDoacaoCommand);

            return Response(retorno);
        }
    }

}
