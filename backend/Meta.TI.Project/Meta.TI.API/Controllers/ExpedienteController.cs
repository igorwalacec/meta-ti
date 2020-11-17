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
    public class ExpedienteController : ApiController
    {
        private readonly IExpedienteApp expedienteApp;

        public ExpedienteController(IExpedienteApp _expedienteApp)
        {
            expedienteApp = _expedienteApp;
        }

        [HttpPut("atualizar")]
        public IActionResult AtualizarExpediente([FromBody] AlterarExpedienteHemocentroCommand comando)
        {
            var idHemocentro = Guid.Parse(User.Claims.Where(c => c.Type == ClaimTypes.PrimaryGroupSid)
                   .Select(c => c.Value).SingleOrDefault());

            comando.DadosExpediente.ForEach(x => x.IdHemocentro = idHemocentro);

            return Response(expedienteApp.AlterarExpedienteHemocentro(comando));
        }
        [HttpGet]
        public IActionResult ObterExpedientePorHemocentro()
        {
            var idHemocentro = Guid.Parse(User.Claims.Where(c => c.Type == ClaimTypes.PrimaryGroupSid)
                   .Select(c => c.Value).SingleOrDefault());
                        
            return Response(expedienteApp.ObterExpedientePorHemocentro(new ObterExpedientePorIdHemocentroCommand { IdHemocentro = idHemocentro }));
        }
    }
}
