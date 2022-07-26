using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SQICS_Api.DTOs;
using SQICS_Api.Helper.POCO;
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
    public class PlanController : ControllerBase
    {
        private readonly IPlanService _service;

        public PlanController(IPlanService service) => _service = service;

        [HttpGet("plans")]
        [Authorize]
        [ProducesResponseType(typeof(List<PlanDTO>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetails), statusCode: StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorDetails), statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(statusCode: StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetAllPlanAsync()
        {
            var plans = await _service.GetAllPlanAsync();

            if (plans is null) return NotFound("No Plan Found!");

            return Ok(plans);
        }

        [HttpGet("search")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(List<PlanDTO>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetails), statusCode: StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorDetails), statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(statusCode: StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> SearchPlanByFilterAsync([FromQuery] string value = "")
        {
            if (value is null) return BadRequest("Invalid Transaction No.!");

            var plans = await _service.GetPlanByFilters(value);

            if (plans is null) return NotFound("Plan Not Found!");

            return Ok(plans);
        }

        [HttpPost("add")]
        [Authorize]
        [ProducesResponseType(typeof(AddPlanDTO), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetails), statusCode: StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorDetails), statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(statusCode: StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> AddNewPlan([FromBody] AddPlanDTO plan)
        {
            if (plan is null) return BadRequest("Invalid Plan!");

            if (!ModelState.IsValid) return BadRequest("Invalid Plan!");

            await _service.AddNewPlanAsync(plan);

            return Ok(plan);
        }

        [HttpGet("add")]
        [Authorize]
        [ProducesResponseType(typeof(List<SubAssyDDLDTO>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetails), statusCode: StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorDetails), statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(statusCode: StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> AddnewPlan()
        {
            var subAssyDdl =  await _service.GetAllSubAssyDDLAsync();

            if (subAssyDdl is null) return NotFound("No SubAssy Found!");

            return Ok(subAssyDdl);
        }

        [HttpGet("servertime")]
        [ProducesResponseType(typeof(List<SubAssyDDLDTO>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetails), statusCode: StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorDetails), statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(statusCode: StatusCodes.Status401Unauthorized)]
        public IActionResult GetServerSystemTime()
        {
            return Ok(DateTime.Now);
        }
    }
}
