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
        [Authorize]
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
        [Authorize]
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
        [Authorize]
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
        [Authorize]
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
        [Authorize]
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
        [Authorize]
        [ProducesResponseType(typeof(DateTime), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetails), statusCode: StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorDetails), statusCode: StatusCodes.Status400BadRequest)]
        public IActionResult GetServerSystemTime()
        {
            return Ok(DateTime.Now);
        }

        [HttpPost("addtransactions")]
        [Authorize]
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
        [Authorize]
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
        [Authorize]
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

        [HttpGet("lineddl/{supplierId:int}")]
        [Authorize]
        [ProducesResponseType(typeof(List<LineDDLDTO>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetails), statusCode: StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorDetails), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetLineDDLAsync(int? supplierId)
        {
            if (supplierId is null) 
                return BadRequest(new ErrorDetails { Message = "Invalid Supplier Id!", StatusCode = 400 });

            var result = await _service.GetLineDataAsync((int)supplierId);

            return Ok(result);
        }

        [HttpGet("stationddl/{lineId:int}")]
        [Authorize]
        [ProducesResponseType(typeof(List<StationDDLDTO>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetails), statusCode: StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorDetails), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetStationDDLAsync(int? lineId)
        {
            if (lineId is null)
                return BadRequest(new ErrorDetails { Message = "Invalid Line Id!", StatusCode = 400 });

            var result = await _service.GetStationDataByLineAsync((int)lineId);

            return Ok(result);
        }

        [HttpPost("deleteplan")]
        [Authorize]
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
        [Authorize]
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
        [Authorize]
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
        [Authorize]
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
        [Authorize]
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
        [Authorize]
        [ProducesResponseType(typeof(List<DefectDTO>), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetails), statusCode: StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorDetails), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetDefectDDLAsync()
        {
            var defects = await _service.GetDefectDDLAsync();

            return Ok(defects);
        }

        [HttpPost("addtransdetails")]
        [Authorize]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetails), statusCode: StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorDetails), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddTransactionDetailsAsync([FromBody] AddTransactionDetailsDTO details)
        {
            if (!ModelState.IsValid || details is null)
                return BadRequest(new ErrorDetails { Message = "Invalid Transaction Details!", StatusCode = 400 });

            await _service.AddTransactionDetails(details);

            return Ok();
        }

        [HttpGet("transbyassylot/{assyLot}")]
        [Authorize]
        [ProducesResponseType(typeof(SubAssyLotDetailsDTO), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetails), statusCode: StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorDetails), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetTransByAssylotAsync(string assyLot)
        {
            if(string.IsNullOrEmpty(assyLot))
                return BadRequest(new ErrorDetails { Message = "Invalid Sub-assy Lot!", StatusCode = 400 });

            var result = await _service.GetSubAssyLotDetailsByLotAsync(assyLot);

            return Ok(result);
        }

        [HttpGet("countbyassylot/{assyLot}")]
        [Authorize]
        [ProducesResponseType(typeof(int), statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetails), statusCode: StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorDetails), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetCountByAssyLotAsync(string assyLot)
        {
            if (string.IsNullOrEmpty(assyLot))
                return BadRequest(new ErrorDetails { Message = "Invalid Sub-assy Lot!", StatusCode = 400 });

            var count = await _service.GetCountByAssyLotAsync(assyLot);

            return Ok(count);
        }

        [HttpGet("incrementcount")]
        [Authorize]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetails), statusCode: StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorDetails), statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> IncrementCountAsync([FromQuery] string assyLot, [FromQuery] int? operatorId)
        {
            if(string.IsNullOrEmpty(assyLot) || operatorId is null)
                return BadRequest(new ErrorDetails { Message = "Invalid Querystrings!", StatusCode = 400 });

            await _service.TriggerIncrementCountAsync(assyLot, (int)operatorId);

            return Ok();
        }
    }
}
