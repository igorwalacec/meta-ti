using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Meta.TI.Domain.Entities;
using Meta.TI.Domain.Repositories;
using Meta.TI.Infra.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Meta.TI.Api.Controllers
{

    [ApiController]
    [Route("[controller]")]
    //[Authorize]
    public class HospitalController : ControllerBase
    {
        private readonly ILogger<HospitalController> _logger;
        private readonly IHospitalRepository _hospitalRepository;

        public HospitalController(ILogger<HospitalController> logger, IHospitalRepository hospitalRepository)
        {
            _logger = logger;
            _hospitalRepository = hospitalRepository;
        }

        [HttpGet]
        public List<Hospital> GetHospitals()
        {
            return _hospitalRepository.GetList(x => x.Id != 0).ToList();
        }
    }
}
