using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SQICS_Api.DTOs;
using SQICS_Api.Model;
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
        [AllowAnonymous]
        [ProducesResponseType(typeof(List<AddTransactionDetailsDTO>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetails), statusCode: StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorDetails), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetTransactionDetailsByTransNoAsync(string transNo)
        {
            if (string.IsNullOrEmpty(transNo)) return BadRequest("Invalid Transaction No.!");

            var details = await _service.GetTransactionDetailsByTransNoAsync(transNo);

            return Ok(details);
        }
       

        [HttpPost("validatepiece")]
        [AllowAnonymous]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetails), statusCode: StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorDetails), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ValidatePiecePartAsync([FromBody] ValidatePiecePartDTO info)
        {
            if (!ModelState.IsValid || info is null) 
                return BadRequest("Invalid Validation Info!");

            var isValid = await _service.ValidatePiecePartAsync(info);

            return (isValid) ? Ok() : NotFound("Invalid PiecePart!");
        }

        [HttpPost("add")]
        [AllowAnonymous]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetails), statusCode: StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorDetails), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddTransactionDetailsAsync([FromBody] AddTransactionDetailsDTO transDetails)
        {
            if (!ModelState.IsValid || transDetails is null) 
                return BadRequest("Invalid Transaction Details!");

            await _service.AddTransactionDetailsAsync(transDetails);

            return Ok();
        }

        [HttpGet("defects")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllDefectsAsync()
        {
            return Ok();
        }

    }
}
