using Meta.TI.Application.Interfaces;
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
    }
}
