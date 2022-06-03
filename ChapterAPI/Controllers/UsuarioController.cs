using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChapterAPI.Models;
using ChapterAPI.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ChapterAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : Controller
    {
        private readonly UsuarioRepository _repository;

        public UsuarioController(UsuarioRepository repository)
        {
            _repository = repository;
        }
        
        [HttpGet]
        [Authorize]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_repository.Listar());
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpGet("{id}")]
        [Authorize]
        public IActionResult BuscarPorId(int id)
        {
            try
            {
                var usuario = _repository.BuscarPorId(id);

                if (usuario == null)
                {
                    return NotFound();
                }

                return Ok(usuario);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        public IActionResult Cadastrar([FromBody] Usuario usuario)
        {
            try
            {
                _repository.Cadastrar(usuario);
                return StatusCode(201);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Atualizar(int id, [FromBody] Usuario usuario)
        {
            try
            {
                _repository.Atualizar(id, usuario);
                return StatusCode(202);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrador")]
        public IActionResult Excluir(int id)
        {
            try
            {
                _repository.Excluir(id);
                return StatusCode(204);
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}

