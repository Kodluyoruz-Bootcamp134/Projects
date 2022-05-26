using Base.Api.Application.Interfaces.Services;
using Base.Api.Application.Models.Const;
using Base.Api.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Base.Api.Infrastructure.Services
{
    internal class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        private readonly HashService _hashService;

        public TokenService(IConfiguration configuration, HashService hashService)
        {
            _configuration = configuration;
            _hashService = hashService;
        }

        public string CreateToken(ApplicationUser user)
        {
            var authClaims = new List<Claim>
                {
                    new Claim(CustomClaimTypes.Id, _hashService.Encode(user.Id)),
                    new Claim(CustomClaimTypes.Mail, user.Email),
                    new Claim(CustomClaimTypes.UserName, user.UserName),
                };

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}