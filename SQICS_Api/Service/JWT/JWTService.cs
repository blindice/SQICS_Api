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

namespace SQICS_Api.Service.JWT
{
    public class JWTService : IJWTService
    {
        private readonly IConfiguration _config;

        public JWTService(IConfiguration config)
        {
            _config = config;
        }

        public async Task<string> GenerateJwtTokenAsync(UserInfoDTO result)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken token = null;

            await Task.Run(() =>
            {
                var key = Encoding.ASCII.GetBytes(_config["Jwt:key"]);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[] {
                    new Claim("id", result.Id.ToString()),
                    new Claim("username", result.Username),
                    new Claim("name", result.FullName),
                    new Claim("supplierid", result.SupplierId.ToString()),
                    new Claim("suppliername", result.SupplierName),
                }),
                    Expires = DateTime.UtcNow.AddHours(1),
                    Issuer = _config["Jwt:Issuer"],
                    Audience = _config["Jwt:Audience"],
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                token = tokenHandler.CreateToken(tokenDescriptor);

            });
            return tokenHandler.WriteToken(token);
        }
    }
}
