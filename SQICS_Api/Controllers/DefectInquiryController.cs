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
    public class DefectInquiryController : ControllerBase
    {
        IDefectInquiryService _service;
        public DefectInquiryController(IDefectInquiryService service)
        {
            _service = service;
        }

        [HttpGet("defectinquiries")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(List<DefectInquiryDTO>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetails), statusCode: StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorDetails), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetDefectInquiryAsync([FromQuery] DefectInquiryParams @params)
        {
            if (@params is null) return BadRequest("Invalid Defect Inquiry!");

            var result = await _service.GetDefectInquiryAsync(@params);

            return Ok(result);
        }
    }
}
