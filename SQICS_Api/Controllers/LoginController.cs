using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _service;
        public LoginController(ILoginService service)
        {
            _service = service;
        }

        [HttpPost("verify")]
        public async Task<IActionResult> Post([FromBody] LoginDTO account)
        {
            if (account is null) return BadRequest("Invalid Account!");

            if (!ModelState.IsValid) return BadRequest("Invalid Account");

            var result = await _service.VerifyUserAsync(account);

            if (result is null) return NotFound("Account Not Found!");

            return Ok(result);
        }
    }
}
