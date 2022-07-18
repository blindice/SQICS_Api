using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SQICS_Api.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQICS_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanController : ControllerBase
    {
        IPlanService _service;
        public PlanController(IPlanService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPlanAsync()
        {
            var plans = await _service.GetAllPlanAsync();

            return Ok(plans);
        }

        [HttpGet("{transNo:int}")]
        public async Task<IActionResult> GetPlanByTransactionNo(int? transNo)
        {
            if (transNo is null) return NotFound();

            var plan = await _service.GetPlanByTransactionNoAsync(transNo);

            return Ok(plan);
        }
    }
}
