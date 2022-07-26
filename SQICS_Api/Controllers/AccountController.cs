using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SQICS_Api.Model;
using SQICS_Api.Service.Interface;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SQICS_Api.Controllers
{
    [Route("api/v1.0/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ILoginService _service;

        public AccountController(ILoginService service)
        {
            _service = service;
        }

        [HttpPost("login")]
        [ProducesResponseType(typeof(string), statusCode:StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetails), statusCode: StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorDetails), statusCode: StatusCodes.Status400BadRequest)]
        [AllowAnonymous]
        public async Task<IActionResult> Post([FromBody] LoginDTO account)
        {
            if (account is null) return BadRequest("Invalid Account!");

            if (!ModelState.IsValid) return BadRequest("Invalid Account");

            var result = await _service.VerifyUserAsync(account);

            if (result is null) return NotFound("Account Not Found!");

            var tokenString = await _service.GenerateJWTTokenAsync(result);

            return Ok(new { Token = tokenString });
        }     
    }
}
