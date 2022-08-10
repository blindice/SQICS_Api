﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
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
        IHubContext<Hubs> _hub;

        public AssemblyController(IAssemblyService service, IHubContext<Hubs> hub)
        {
            _service = service;
            _hub = hub;
        }

        [HttpGet("operatordetails/{operatorId}")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(SubAssyByOperatorIdDTO), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetails), statusCode: StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorDetails), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetOperatorDetailsAsync(string operatorId)
        {
            if (!ModelState.IsValid || operatorId is null)
                return BadRequest("Invalid Operator Id!");

            var operatorDetails = await _service.GetOperatorDetailsAsync(operatorId);

            return Ok(operatorDetails);
        }

        [HttpGet("subassies/{supplierId:int}")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(SubAssyDDLDTO), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetails), statusCode: StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorDetails), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetDDLSubassiesAsync(int? supplierId)
        {
            if (supplierId is null) return BadRequest("Invalid Supplier Id!");

            var subAssies = await _service.GetSubAssyDdlDataAsync((int)supplierId);

            return Ok(subAssies);
        }

        [HttpGet("subassybycode")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(SubAssyDetailsDTO), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetails), statusCode: StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorDetails), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetSubAssyByCodeAsync([FromQuery] int? supplierId, [FromQuery] string subAssyCode)
        {
            if(supplierId is null || subAssyCode is null)
                return BadRequest("Invalid Query Strings!");

            var subAssy = await _service.GetSubAssyByCodeAsync((int)supplierId, subAssyCode);

            return Ok(subAssy);
        }


        [HttpGet("subassybyname")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(SubAssyDetailsDTO), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetails), statusCode: StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorDetails), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetSubAssyByNameAsync([FromQuery] int? supplierId, [FromQuery] string subAssyName)
        {
            if (supplierId is null || subAssyName is null)
                return BadRequest("Invalid Query Strings!");

            var subAssy = await _service.GetSubAssyByNameAsync((int)supplierId, subAssyName);

            return Ok(subAssy);
        }

        [HttpGet("servertime")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(DateTime), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetails), statusCode: StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorDetails), statusCode: StatusCodes.Status400BadRequest)]
        public IActionResult GetServerSystemTime()
        {
            return Ok(DateTime.Now);
        }

        [HttpPost("addtransactions")]
        [AllowAnonymous]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetails), statusCode: StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorDetails), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddTransactionsAsync([FromBody] List<AddPlanDTO> plans)
        {
            if (plans is null) return BadRequest("Invalid plans!");

            if (plans.Count == 0) return NotFound("No Plan Found to Add!");

            await _service.AddPlansAsync(plans);

            return Ok();
        }

        [HttpGet("currentplans")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(List<CurrentPlanDTO>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetails), statusCode: StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorDetails), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetCurrentPlanAsync([FromQuery] int? lineId)
        {
            if (lineId is null) return BadRequest("Invalid Line Id!");

            var plans = await _service.GetCurrentPlansByLineIdAsync((int)lineId);

            return Ok(plans);
        }

        [HttpPost("startprocess")]
        [AllowAnonymous]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetails), statusCode: StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorDetails), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> StartProcessAsync([FromBody] AddOngoingDTO transaction)
        {
            if (!ModelState.IsValid || transaction is null) return BadRequest("Invalid Transaction!");

            await _service.StartProcessAsync(transaction);

            return Ok();
        }

        [HttpGet("ddldatas/{supplierId:int}")]
        [AllowAnonymous]
        [ProducesResponseType(typeof((List<StationDDLDTO>, List<LineDDLDTO>)), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetails), statusCode: StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorDetails), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetDDLDataAsync(int? supplierId)
        {
            if (supplierId is null) return BadRequest("Invalid Supplier Id!");

            var result = await _service.GetDDLDataAsync((int)supplierId);

            return Ok(new { Stations = result.Item1, Lines = result.Item2});
        }

        [HttpPost("deleteplan")]
        [AllowAnonymous]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetails), statusCode: StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorDetails), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeletePlan([FromBody] DeletePlanDTO field)
        {
            if (field is null) return BadRequest("Invalid Transaction!");

            await _service.DeletePlanAsync(field);

            return Ok();
        }

        [HttpPost("print")]
        [AllowAnonymous]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetails), statusCode: StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorDetails), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Print([FromBody] PrintDTO info)
        {
            if (info is null) return BadRequest("Invalid Line Id!");

            var plans = await _service.GetCurrentPlansByLineIdAsync((int)info.LineId);

            await _hub.Clients.All.SendAsync("Print", plans);

            return Ok();
        }
    }
}
