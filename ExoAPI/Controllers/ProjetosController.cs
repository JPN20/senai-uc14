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
    [Authorize]
    public class ProjetosController : Controller
    {
        private readonly ProjetoRepository _repository;

        public ProjetosController(ProjetoRepository repository)
        {
            _repository = repository;
        }
        
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_repository.Listar());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            try
            {
                var projeto = _repository.BuscarPorId(id);

                return (projeto != null) ? Ok(projeto) : NotFound("Projeto não encontrado");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        [HttpPost]
        public IActionResult Cadastrar([FromBody]Projeto projeto)
        {
            try
            {
                return Ok(_repository.Cadastrar(projeto));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
                
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, [FromBody]Projeto projeto)
        {
            try
            {
                return Ok(_repository.Atualizar(id, projeto));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        [HttpDelete("{id}")]
        public IActionResult Excluir(int id)
        {
            try
            {
                if (_repository.Excluir(id))
                {
                    return Ok("Projeto removido");
                }

                return NotFound("Projeto não encontrado");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

