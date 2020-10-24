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
    public class EstoqueSanquineoController : ApiController
    {
        private readonly IEstoqueSanguineoApp estoqueSanguineoApp;
        public EstoqueSanquineoController(IEstoqueSanguineoApp _estoqueSanguineoApp)
        {
            estoqueSanguineoApp = _estoqueSanguineoApp;
        }

        [HttpGet]
        public IActionResult ObterTodosEstoqueSanguineo()
        {
            var idHemocentro = Guid.Parse(User.Claims.Where(c => c.Type == ClaimTypes.PrimaryGroupSid)
                   .Select(c => c.Value).SingleOrDefault());

            ConsultarEstoqueSanguineoPorHemocentroCommand comando = new ConsultarEstoqueSanguineoPorHemocentroCommand();
            comando.IdHemocentro = idHemocentro;

            return Response(estoqueSanguineoApp.ObterTodosEstoqueSanguineo(comando));
        }

        [HttpGet("/{idTipoSanguineo}")]
        public IActionResult ObterEstoqueSanquineoPorTipo([FromRoute] int idTipoSanguineo)
        {
            var idHemocentro = Guid.Parse(User.Claims.Where(c => c.Type == ClaimTypes.PrimaryGroupSid)
                   .Select(c => c.Value).SingleOrDefault());
            ConsultarEstoqueSanquineoCommand comando = new ConsultarEstoqueSanquineoCommand();
            comando.IdHemocentro = idHemocentro;
            comando.IdTipoSanguineo = idTipoSanguineo;

            return Response(estoqueSanguineoApp.ObterEstoqueSanquineoPorTipo(comando));
        }

        [HttpPut("atualizar")]
        public IActionResult AtualizarEstoqueSanguineo([FromBody] AlterarEstoqueSanguineoCommand comando)
        {
            var idHemocentro = Guid.Parse(User.Claims.Where(c => c.Type == ClaimTypes.PrimaryGroupSid)
                   .Select(c => c.Value).SingleOrDefault());

            comando.DadosEstoqueSanguineo.ForEach(x => x.IdHemocentro = idHemocentro);
           
            return Response(estoqueSanguineoApp.AlterarEstoqueSanguineo(comando));
        }
    }
}
