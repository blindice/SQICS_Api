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
    public class PlanController : ControllerBase
    {
        private readonly IPlanService _service;

        public PlanController(IPlanService service) => _service = service;

        [HttpGet("plans")]
        public async Task<IActionResult> GetAllPlanAsync()
        {
            var plans = await _service.GetAllPlanAsync();

            if (plans is null) return NotFound("No Plan Found!");

            return Ok(plans);
        }

        [HttpGet("{transNo}")]
        public async Task<IActionResult> GetPlanByTransactionNo(string transNo)
        {
            if (transNo is null) return BadRequest("Invalid Transaction No.!");

            var plan = await _service.GetPlanByTransactionNoAsync(transNo);

            if (plan is null) return NotFound("Plan Not Found!");

            return Ok(plan);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddNewPlan([FromBody] AddPlanDTO plan)
        {
            if (plan is null) return BadRequest("Invalid Plan!");

            if (!ModelState.IsValid) return BadRequest("Invalid Plan!");

            await _service.AddNewPlanAsync(plan);

            return Ok(plan);
        }

        [HttpGet("add")]
        public async Task<IActionResult> AddnewPlan()
        {
            var subAssyDdl =  await _service.GetAllSubAssyDDLAsync();

            if (subAssyDdl is null) return NotFound("No SubAssy Found!");

            return Ok(subAssyDdl);
        }
    }
}
