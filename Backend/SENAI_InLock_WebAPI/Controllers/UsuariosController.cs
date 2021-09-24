using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using senai.inLock.webAPI.Domains;
using SENAI_InLock_WebAPI.Domains;
using SENAI_InLock_WebAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SENAI_InLock_WebAPI.Controllers
{
    [Produces("application/json")]
  
    [Route("api/[controller]")]

    [ApiController]
    public class UsuariosController : ControllerBase
    {
       
        private IUsuarioRepository _usuarioRepository { get; set; }
        public UsuariosController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpPost("Login")]
        public IActionResult Login(Usuario login)
        {
            
            Usuario usuarioBuscado = _usuarioRepository.Login(login.Email, login.Senha);

            
            if (usuarioBuscado == null)
            {
               
                return NotFound("E-mail ou senha inválidos!");
            }

            

            
            var claims = new[]
            {
             
                new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),
                new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString()),
                new Claim(ClaimTypes.Role, usuarioBuscado.IdTipoUsuario.ToString())
            };

            
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("inlock-chave-autenticacao"));

           
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            
            var token = new JwtSecurityToken(
                issuer: "inLock.webAPI",                
                audience: "inLock.webAPI",              
                claims: claims,                         
                expires: DateTime.Now.AddMinutes(30),   
                signingCredentials: creds               
            );

           
            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            });
        }
    }
}

