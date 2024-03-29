using Meta.TI.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Meta.TI.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EstadoController : ApiController
    {
        private readonly IEstadoApp estadoApp;
        public EstadoController(IEstadoApp _estadoApp)
        {
            estadoApp = _estadoApp;
        }

        [HttpGet]
        [Route("obter-estados")]        
        public IActionResult ObterEstados()
        {
            return Response(estadoApp.ObterEstados());
        }
    }
}
