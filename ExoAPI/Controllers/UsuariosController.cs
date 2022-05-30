using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExoAPI.Models;
using ExoAPI.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExoAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]    
    public class UsuariosController : Controller
    {
        private readonly UsuarioRepository _repository;

        public UsuariosController(UsuarioRepository repository)
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
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
       
        [HttpGet("{id}")]
        [Authorize]
        public IActionResult BuscarPorId(int id)
        {
            try
            {
                var usuario = _repository.BuscarPorId(id);

                return (usuario != null) ? Ok(usuario) : NotFound("Usuário não encontrado");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        [HttpPost]
        public IActionResult Cadastrar([FromBody]Usuario usuario)
        {
            try
            {
                return Ok(_repository.Cadastrar(usuario));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
                
        [HttpPut("{id}")]
        [Authorize(Roles = "1")]
        public IActionResult Atualizar(int id, [FromBody]Usuario usuario)
        {
            try
            {
                return Ok(_repository.Atualizar(id, usuario));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
                
        [HttpDelete("{id}")]
        [Authorize(Roles = "1")]
        public IActionResult Excluir(int id)
        {
            try
            {
                if (_repository.Excluir(id))
                {
                    return Ok("Usuário removido");
                }

                return NotFound("Usuário não encontrado");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

