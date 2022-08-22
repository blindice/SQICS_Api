using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
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
        IPlanService _service;
        IHubContext<Hubs> _hub;

        public PlanController(IPlanService service, IHubContext<Hubs> hub)
        {
            _service = service;
            _hub = hub;
        }

        [HttpPost("addtogroup")]
        [AllowAnonymous]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetails), statusCode: StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorDetails), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddToGroupAsync([FromBody] GroupDTO group)
        {
            if (!ModelState.IsValid || group is null)
                return BadRequest(new ErrorDetails { Message = "Invalid Group Info!", StatusCode = 400 });

            await _hub.Groups.AddToGroupAsync(group.ConnectionId, group.GroupName);

            return Ok();
        }

        [HttpGet("operatordetails/{operatorId}")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(SubAssyByOperatorIdDTO), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetails), statusCode: StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorDetails), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetOperatorDetailsAsync(string operatorId)
        {
            if (!ModelState.IsValid || operatorId is null)
                return BadRequest(new ErrorDetails { Message = "Invalid Operator Id!", StatusCode = 400 });

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
            if (supplierId is null) 
                return BadRequest(new ErrorDetails { Message = "Invalid Supplier Id!", StatusCode = 400 });

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
            if (supplierId is null || subAssyCode is null)
                return BadRequest(new ErrorDetails { Message = "Invalid Query string!", StatusCode = 400 });

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
                return BadRequest(new ErrorDetails { Message = "Invalid Query String!", StatusCode = 400 });

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
            if (plans is null) 
                return BadRequest(new ErrorDetails { Message = "Invalid Plans!", StatusCode = 400 });

            if (plans.Count == 0) 
                return NotFound(new ErrorDetails { Message = "No Plan Found to Add!", StatusCode = 404 });

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
            if (lineId is null) 
                return BadRequest(new ErrorDetails { Message = "Invalid Line Id!", StatusCode = 400 });

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
            if (!ModelState.IsValid || transaction is null) 
                return BadRequest(new ErrorDetails { Message = "Invalid Transaction!", StatusCode = 400 });

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
            if (supplierId is null) 
                return BadRequest(new ErrorDetails { Message = "Invalid Supplier Id!", StatusCode = 400 });

            var result = await _service.GetDDLDataAsync((int)supplierId);

            return Ok(new { Stations = result.Item1, Lines = result.Item2 });
        }

        [HttpPost("deleteplan")]
        [AllowAnonymous]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetails), statusCode: StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorDetails), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeletePlan([FromBody] DeletePlanDTO field)
        {
            if (!ModelState.IsValid || field is null) 
                return BadRequest(new ErrorDetails { Message = "Invalid Transaction!", StatusCode = 400 });

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
            if (!ModelState.IsValid || info is null) 
                return BadRequest(new ErrorDetails { Message = "Invalid Line Id!", StatusCode = 400 });

            var plans = await _service.GetCurrentPlansByLineIdAsync((int)info.LineId);

            await _hub.Clients.Group($"LineId-{info.LineId}").SendAsync("Print", plans);

            return Ok();
        }

        [HttpPost("verifypiecepart")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(string), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetails), statusCode: StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorDetails), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetPiecePartnameAsync([FromQuery] int? supplierId, [FromQuery] string pieceCode)
        {
            if(supplierId is null || pieceCode is null)
                return BadRequest(new ErrorDetails { Message = "Invalid Query string!", StatusCode = 400 });

            var info = new ValidatePieceBySupplierDTO() { PiecePartCode = pieceCode, SupplierId = (int)supplierId };

            var partName = await _service.GetPiecePartnameAsync(info);

            return Ok(partName);
        }

        [HttpPost("verifysubassy")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(string), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetails), statusCode: StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorDetails), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetSubAssyNameAsync([FromQuery] int? supplierId, [FromQuery] string pieceCode, 
            [FromQuery] string assyCode)
        {
            if (supplierId is null || pieceCode is null)
                return BadRequest(new ErrorDetails { Message = "Invalid Query string!", StatusCode = 400 });

            var info = new ValidateSubAssyBySupplierDTO() 
            { 
                PieceCode = pieceCode, 
                SupplierId = (int)supplierId,
                AssyCode = assyCode
            };

            var partName = await _service.GetSubAssyNameAsync(info);

            return Ok(partName);
        }

        [HttpPost("addassydefect")]
        [AllowAnonymous]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetails), statusCode: StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorDetails), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddAssyDefectAsync([FromBody] AddAssyDefectDTO dto)
        {
            if (!ModelState.IsValid || dto is null)
                return BadRequest(new ErrorDetails { Message = "Invalid Assy Defect!", StatusCode = 400 });

            await _service.AddAssyDefectAsync(dto);

            return Ok();
        }

        [HttpGet("defectddl")]
        public async Task<IActionResult> GetDefectDDLAsync()
        {
            var defects = await _service.GetDefectDDLAsync();

            return Ok(defects);
        }
    }
}
