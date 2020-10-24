using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Meta.TI.Application.Interfaces;
using Meta.TI.Domain.Commands;
using Meta.TI.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Meta.TI.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnderecoController : ApiController
    {
        private readonly IEnderecoApp enderecoApp;
        public EnderecoController(IEnderecoApp _enderecoApp)
        {
            enderecoApp = _enderecoApp;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("atualizar-endereco-usuario")]
        public IActionResult AlterarEnderecoUsuario([FromBody] AlterarEnderecoUsuarioCommand comando)
        {
            var idUsuario = Guid.Parse(User.Claims.Where(c => c.Type == ClaimTypes.PrimarySid)
                   .Select(c => c.Value).SingleOrDefault());

            comando.IdUsuario = idUsuario;

            return Response(enderecoApp.AlterarEnderecoUsuario(comando));
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("atualizar-endereco-hemocentro")]
        public IActionResult AlterarEnderecoHemocentro([FromBody] AlterarEnderecoHemocentroCommand comando)
        {
            var idHemocentro = Guid.Parse(User.Claims.Where(c => c.Type == ClaimTypes.PrimaryGroupSid)
                   .Select(c => c.Value).SingleOrDefault());
            
            comando.IdHemocentro = idHemocentro;
          
            return Response(enderecoApp.AlterarEnderecoHemocentro(comando));
        }
    }
}
