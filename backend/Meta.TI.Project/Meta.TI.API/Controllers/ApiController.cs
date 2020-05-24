using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Meta.TI.Domain.Commands;
using Microsoft.AspNetCore.Mvc;

namespace Meta.TI.API.Controllers
{
    public abstract class ApiController : ControllerBase
    {
        protected new IActionResult Response(GenericCommandResult result)
        {
            if (result.Sucess)
            {
                return Ok(new
                {
                    success = true,
                    message = result.Message,
                    data = result.Data
                });
            }

            return BadRequest(new
            {
                success = false,
                message = result.Message,
                data = result.Data
            });
        }
    }
}
