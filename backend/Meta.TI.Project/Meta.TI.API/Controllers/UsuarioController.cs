using System;
using Meta.TI.Application.Interfaces;
using Meta.TI.Domain.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Meta.TI.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ApiController
    {
        private readonly IUsuarioApp usuarioApp;
        public UsuarioController(IUsuarioApp _usuarioApp)
        {
            usuarioApp = _usuarioApp;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("get-token")]
        public IActionResult CriarUsuario([FromBody] TokenCommand usuario)
        {            
            return Response(usuarioApp.GetToken(usuario));
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("criar-usuario")]
        public IActionResult CriarUsuario([FromBody] CriacaoUsuarioCommand usuario)
        {
            return Response(usuarioApp.CriarUsuario(usuario));
        }
    }
}
