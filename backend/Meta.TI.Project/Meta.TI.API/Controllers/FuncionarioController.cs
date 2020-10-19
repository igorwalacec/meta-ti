using Meta.TI.Application.Interfaces;
using Meta.TI.Domain.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Meta.TI.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FuncionarioController : ApiController
    {
        private readonly IFuncionarioApp funcionarioApp;
        public FuncionarioController(IFuncionarioApp _funcionarioApp)
        {
            funcionarioApp = _funcionarioApp;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("get-token")]
        public IActionResult CriarFuncionario([FromBody] TokenCommand funcionario)
        {
            return Response(funcionarioApp.GetToken(funcionario));
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("criar-funcionario")]
        public IActionResult CriarFuncionario([FromBody] CriacaoFuncionarioCommand funcionario)
        {
            return Response(funcionarioApp.CriarFuncionario(funcionario));
        }
    }
}
