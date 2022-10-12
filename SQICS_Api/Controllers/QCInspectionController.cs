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
        public async Task<IActionResult> AddQCInspectionAsync([FromBody] AddQCInspectionDTO inspection)
        {
            if (!ModelState.IsValid || inspection is null)
                return BadRequest(new ErrorDetails { Message = "Invalid Transaction!", StatusCode = 400 });

            await _service.AddInspectionAsync(inspection);

            return Ok();
        }

    }
}
