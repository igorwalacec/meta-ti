using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Meta.TI.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Meta.TI.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HistoricoAptidaoController : ApiController
    {
        private readonly IHistoricoAptidaoApp historicoAptidaoApp;
        public HistoricoAptidaoController(IHistoricoAptidaoApp _historicoAptidaoApp)
        {
            historicoAptidaoApp = _historicoAptidaoApp;
        }

        [HttpGet]
        [Route("calcular-daysoff")]
        //[Authorize(Roles = "doador")]
        public IActionResult CalcularDayOff()
        {
            var idUsuario = Guid.Parse(User.Claims.Where(c => c.Type == ClaimTypes.PrimarySid)
                   .Select(c => c.Value).SingleOrDefault());

            var retorno = historicoAptidaoApp.CalcularDayOff(idUsuario);

            return Response(retorno);
        }
    }

}
