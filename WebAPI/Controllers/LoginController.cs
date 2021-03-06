﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using WebAPI.Models;
using WebAPI.Utils;
using WebAPI.ViewModel;

namespace WebAPI.Controllers
{
    [Route("api/login")]
    public class LoginController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly DatabaseContext _db;

        public LoginController(IConfiguration configuration, DatabaseContext db)
        {
            _configuration = configuration;
            _db = db;
        }

        public UserModel AuthLogin(string ra, string password)
        {
            var user = _db.User.Where(u => u.ra == ra).FirstOrDefault();
            if (user != null)
            {
                // Melhorar método de validação de login
                string comparePassword = user.password; // new EncryptionService().Decrypt(user.password);
                string loginPassword = password; // new EncryptionService().Decrypt(password);

                if (comparePassword == loginPassword)
                {
                    return user;
                }

                return null;
            }
            return null;
        }

        [HttpPost]
        public IActionResult Login([FromBody] LoginViewModel user)
        {
            UserModel userBd = AuthLogin(user.ra, user.password);
            if (userBd != null)
            {
                var claims = new[]
                {
                    new Claim("name", userBd.name),
                    new Claim("ra", userBd.ra),
                    new Claim("role", userBd.isAdmin ? "admin" : "teacher")
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["SecurityKey"]));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "PerguntemeAPI",
                    audience: "PerguntemeAPI",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: creds
                );

                return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
            }

            return BadRequest("Credenciais Inválidas!");
        }
    }
}