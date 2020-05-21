using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Meta.TI.Application.Interfaces;
using Meta.TI.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Meta.TI.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EstadoController : ControllerBase
    {
        private readonly IEstadoService estadoService;
        public EstadoController(IEstadoService _estadoService)
        {
            estadoService = _estadoService;
        }
        [Route("obter-estados")]
        public IEnumerable<EstadoViewModel> ObterEstados()
        {
            return estadoService.ObterEstados();
        }
    }
}