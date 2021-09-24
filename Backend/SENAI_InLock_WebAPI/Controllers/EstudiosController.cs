using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public class EstudiosController : ControllerBase
    {
        private IEstudiosRepository _estudioRepository { get; set; }
        public EstudiosController()
        {
            _estudioRepository = new EstudioRepository();
        }
        [HttpGet("jogos")]
        public IActionResult ListarTodos()
        {
            try
            {
                return Ok(_estudioRepository.ListarComJogos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}