﻿using eShop.Infrastructure.DTO;
using eShop.Infrastructure.Extensions;
using eShop.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using eShop.Domain.Entities;

namespace eShop.Infrastructure.Services
{
    public class JwtService : IJwt
    {
        public IConfiguration _configuration { get; }

        public JwtService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Jwt CreateToken(int userId, string role)
        {
            var now = DateTime.UtcNow;

            var claims = new Claim[]
            {
                    new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
                    new Claim(JwtRegisteredClaimNames.UniqueName, userId.ToString()),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, now.ToTimestamp().ToString(), ClaimValueTypes.Integer64),
                    new Claim(ClaimTypes.Role, role)
            };

            var expires = now.AddMinutes(_configuration.GetValue<double>("Auth:Jwt:TimeExpirationInMinutes"));
            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Auth:Jwt:Key"])),
                SecurityAlgorithms.HmacSha256);

            var jwt = new JwtSecurityToken(
                issuer: _configuration["Auth:Jwt:Issuer"],
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: expires,
                signingCredentials: signingCredentials
            );

            var token = new JwtSecurityTokenHandler().WriteToken(jwt);

            return new Jwt
            {
                Token = token,
                Expires = expires.ToTimestamp()
            };
        }
    }
}