using System;
using Meta.TI.Application.Interfaces;
using Meta.TI.Domain.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Meta.TI.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HemocentroController : ApiController
    {
        private readonly IHemocentroApp hemocentroApp;
        public HemocentroController(IHemocentroApp _hemocentroApp)
        {
            hemocentroApp = _hemocentroApp;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("criar")]
        public IActionResult CriarHemocentro([FromBody] CriacaoHemocentroCommand hemocentro)
        {
            return Response(hemocentroApp.CriarHemocentro(hemocentro));
        }

        [AllowAnonymous]
        [HttpPut]
        [Route("alterar-status")]
        public IActionResult AlterarStatusHemocentro([FromBody] AlterarAtivoHemocentroCommand ativoHemocentro)
        {
            return Response(hemocentroApp.AlterarStatusHemocentro(ativoHemocentro));
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("obter-todos")]
        public IActionResult AlterarStatusHemocentro()
        {
            return Response(hemocentroApp.ObterTodosHemocentros());
        }
    }
}
