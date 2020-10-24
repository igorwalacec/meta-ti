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
    public class RecompensasController : ApiController
    {
        private readonly IRecompensasApp recompensaApp;

        public RecompensasController(IRecompensasApp _recompensaApp)
        {
            recompensaApp = _recompensaApp;
        }

        [HttpPost]
        [Route("cadastrar-level")]
        [Authorize(Roles = "doador")]
        public IActionResult AdicionarLevel([FromBody] AdicionarLevelCommand levelCommand)
        {
            return Response(recompensaApp.AdicionarLevel(levelCommand));
        }

        [HttpPost]
        [Route("cadastrar-patrocinador")]
        [Authorize(Roles = "doador")]
        public IActionResult AdicionarPatrocinador([FromBody] AdicionarPatrocinadorCommand patrocinadorCommand)
        {
            return Response(recompensaApp.AdicionarPatrocinador(patrocinadorCommand));
        }

        [HttpPost]
        [Route("cadastrar-recompensas")]
        [Authorize(Roles = "doador")]
        public IActionResult AdicionarRecompensas([FromBody] AdicionarRecompensasCommand recompensaCommand)
        {
            return Response(recompensaApp.AdicionarRecompensas(recompensaCommand));
        }

        [HttpPost]
        [Route("desativar-level")]
        [Authorize(Roles = "doador")]
        public IActionResult DesativarLevelPorId([FromBody] DesativarLevelPorIdCommand desativarLevel)
        {
            return Response(recompensaApp.DesativarLevelPorId(desativarLevel));
        }

        [HttpPost]
        [Route("desativar-patrocinador")]
        [Authorize(Roles = "doador")]
        public IActionResult DesativarPatrocinadorPorId([FromBody] DesativarPatrocinadorPorIdCommand desativarPatrocinador)
        {
            return Response(recompensaApp.DesativarPatrocinadorPorId(desativarPatrocinador));
        }

        [HttpPost]
        [Route("desativar-recompensas")]
        [Authorize(Roles = "doador")]
        public IActionResult DesativarRecompensasPorId([FromBody] DesativarRecompensasPorIdCommand desativarRecompensa)
        {
            return Response(recompensaApp.DesativarRecompensasPorId(desativarRecompensa));
        }

        [HttpGet]
        [Route("listar-level")]
        [Authorize(Roles = "doador")]
        public IActionResult ListarLevel()
        {
            return Response(recompensaApp.ListarLevel());
        }

        [HttpGet]
        [Route("listar-patrocinador")]
        [Authorize(Roles = "doador")]
        public IActionResult ListarPatrocinador()
        {
            return Response(recompensaApp.ListarPatrocinador());
        }

        [HttpGet]
        [Route("listar-recompensas")]
        [Authorize(Roles = "doador")]
        public IActionResult ListarRecompensas()
        {
            return Response(recompensaApp.ListarRecompensas());
        }

    }
}
