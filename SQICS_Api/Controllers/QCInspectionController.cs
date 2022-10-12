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
    [Route("api/[controller]")]
    [ApiController]
    public class QCInspectionController : ControllerBase
    {
        IQCInspectionService _service;

        public QCInspectionController(IQCInspectionService service) => _service = service;

        [HttpPost("addqcinspection")]
        [Authorize]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetails), statusCode: StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorDetails), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddQCInspectionAsync([FromBody] AddQCInspectionDTO inspection)
        {
            if (!ModelState.IsValid || inspection is null)
                return BadRequest(new ErrorDetails { Message = "Invalid Transaction!", StatusCode = 400 });

            await _service.AddInspectionAsync(inspection);

            return Ok();
        }

        [HttpGet("getinspectionmodes")]
        [ProducesResponseType(typeof(InspectionModeDDLDTO), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetails), statusCode: StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorDetails), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetInspectionModeDDLAsync()
        {
            var inspectionModes = await _service.GetInspectionModeDDLAsync();

            return Ok(inspectionModes);
        }
    }
}
