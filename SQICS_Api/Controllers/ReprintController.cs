using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SQICS_Api.DTOs;
using SQICS_Api.Model;
using SQICS_Api.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQICS_Api.Controllers
{
    [Route("api/v1.0/[controller]")]
    [ApiController]
    public class ReprintController : ControllerBase
    {
        IReprintService _service;
        public ReprintController(IReprintService service)
        {
            _service = service;
        }

        [HttpGet("getlotlabels")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(List<LotLabelDTO>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetails), statusCode: StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorDetails), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllLotLabels()
        {
            var lotLabels = await _service.GetAllLotLabelAsync();

            return Ok(lotLabels);
        }

        [HttpPost("printlotlabel")]
        [AllowAnonymous]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetails), statusCode: StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorDetails), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateLotLabelAsync([FromBody] UpdateLotLabelDTO details)
        {
            if(details is null) return BadRequest(new ErrorDetails { Message = "Invalid Group Info!", StatusCode = 400 });

            await _service.PrintLotLabelAsync(details);

            return Ok();
        }
    }
}
