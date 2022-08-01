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
    public class AssemblyController : ControllerBase
    {
        IAssemblyService _service;
        public AssemblyController(IAssemblyService service)
        {
            _service = service;
        }

        [HttpPost("validateoperator")]
        [AllowAnonymous]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetails), statusCode: StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorDetails), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ValidateOperatorAsync([FromBody] ValidateOperatorDTO info)
        {
            if (!ModelState.IsValid || info is null)
                return BadRequest("Invalid Validation Info!");

            var isValid = await _service.ValidateOperatorAsync(info);

            return (isValid) ? Ok() : NotFound("Invalid Operator!");
        }

        [HttpGet("subassies/{supplierId:int}")]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetails), statusCode: StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorDetails), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetDDLSubassiesAsync(int? supplierId)
        {
            if (supplierId is null) return BadRequest("Invalid Supplier Id!");

            var subAssies = await _service.GetSubAssyDdlDataAsync((int)supplierId);

            return Ok(subAssies);
        }
    }
}
