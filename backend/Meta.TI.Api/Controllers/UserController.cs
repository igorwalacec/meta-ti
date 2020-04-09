using Meta.TI.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Meta.TI.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IJwtService _jwtService;
        public UserController(IJwtService jwtService)
        {
            _jwtService = jwtService;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("gettoken")]
        public ActionResult Login(string email, string password)
        {
            var token = _jwtService.GenerateSecurityToken(email, password);

            if (string.IsNullOrEmpty(token))
            {
                return StatusCode(401, "Usuário não encontrado");
            }
            else
            {
                return StatusCode(200, new { token });
            }
        }
    }
}