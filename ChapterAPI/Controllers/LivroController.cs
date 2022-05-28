using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChapterAPI.Models;
using ChapterAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ChapterAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class LivroController : Controller
    {
        private readonly LivroRepository _repository;

        public LivroController(LivroRepository repository)
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
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            try
            {
                var livro = _repository.BuscarPorId(id);

                if (livro == null)
                {
                    return NotFound();
                }

                return Ok(livro);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        public IActionResult Cadastrar([FromBody]Livro livro)
        {
            try
            {
                _repository.Cadastrar(livro);
                return StatusCode(201);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, [FromBody]Livro livro)
        {
            try
            {
                _repository.Atualizar(id, livro);
                return StatusCode(202);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpDelete("{id}")]
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

