using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SQICS_Api.Repository.Interface;
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
        ITransactionRepository _repo;
        public TransactionController(ITransactionRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTransactionAsync()
        {
            var result = await _repo.GetAllTransactionAsync();

            return Ok(result);
        }

        [HttpGet("{transNo}")]
        public async Task<IActionResult> GetTransactionByTransactionNoAsync(int transNo)
        {
            var result = await _repo.GetTransactionByTransNoAsync(transNo);

            return Ok(result);
        }
    }
}
