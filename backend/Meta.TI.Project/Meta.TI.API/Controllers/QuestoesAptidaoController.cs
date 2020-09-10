using Meta.TI.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Meta.TI.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuestoesAptidaoController : ApiController
    {
        private readonly IQuestoesAptidaoApp questoesAptidaoApp;
        public QuestoesAptidaoController(IQuestoesAptidaoApp _questoesAptidaoApp)
        {
            questoesAptidaoApp = _questoesAptidaoApp;
        }

        [HttpGet]
        [Route("obter-questoesaptidao")]
        [Authorize(Roles = "doador")]
        public IActionResult ObterQuestoesAptidao()
        {
            return Response(questoesAptidaoApp.ObterQuestoesAptidao());
        }
    }
}
