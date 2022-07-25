using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SQICS_Api.DTOs;
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

        [HttpPost("validateoperator")]
        public async Task<IActionResult> ValidateOperatorAsync([FromBody] ValidateOperatorDTO info)
        {
            if (!ModelState.IsValid) return BadRequest("Invalid Validation Info!");

            if (info is null) return BadRequest("Invalid Validation Info!");

            var isValid = await _service.ValidateOperatorAsync(info);

            return (isValid) ? Ok() : NotFound("Invalid Operator!");
        }

        [HttpPost("validatepiece")]
        public async Task<IActionResult> ValidatePiecePartAsync([FromBody] ValidatePiecePartDTO info)
        {
            if (!ModelState.IsValid) return BadRequest("Invalid Validation Info!");

            if (info is null) return BadRequest("Invalid Validation Info!");

            var isValid = await _service.ValidatePiecePartAsync(info);

            return (isValid) ? Ok() : NotFound("Invalid PiecePart!");
        }
    }
}
