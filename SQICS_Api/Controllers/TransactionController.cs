using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SQICS_Api.Repository.Interface;
using SQICS_Api.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQICS_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        public TransactionController()
        {

        }

        [HttpGet]
        public async Task<IActionResult> GetAllTransactionAsync()
        {
            return Ok();
        }

        [HttpGet("{transNo}")]
        public async Task<IActionResult> GetTransactionByTransactionNoAsync(int transNo)
        {
            return Ok();
        }
    }
}
