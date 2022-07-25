using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SQICS_Api.Repository.Interface;
using SQICS_Api.Service.Interface;
using SQICS_Api.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQICS_Api.Controllers
{
    [Route("api/v1.0/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        ITransactionService _service;
        public TransactionController(ITransactionService service)
        {
            _service = service;
        }

        [HttpGet("{transNo}")]
        public async Task<IActionResult> GetTransactionDetailsByTransNoAsync(string transNo)
        {
            if (string.IsNullOrEmpty(transNo)) return BadRequest("Invalid Transaction No.!");

            var details = await _service.GetTransactionDetailsByTransNoAsync(transNo);

            return Ok(details);
        }

        [HttpGet("validateOperator/{empId}")]
        public async Task<IActionResult> ValidateOperatorAsync(string empId)
        {
            if (string.IsNullOrEmpty(empId)) return BadRequest("Invalid Employee Id!");

            var isValid = await _service.ValidateOperatorAsync(empId);

            return (isValid) ? Ok() : NotFound("Invalid Operator!");
        }
    }
}
