using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SENAI_InLock_WebAPI.Domains;
using SENAI_InLock_WebAPI.Interfaces;
using SENAI_InLock_WebAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SENAI_InLock_WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class JogosController : ControllerBase
    {
        private IJogoRepository _jogoRepository { get; set; }
        public JogosController()
        {
            _jogoRepository = new JogoRepository();
        }
        [HttpGet]
        public IActionResult ListarTodos()
        {
            try
            {
                return Ok(_jogoRepository.ListarTodos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(Jogo novoJogo)
        {
            try
            {
                _jogoRepository.Cadastrar(novoJogo);

                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
