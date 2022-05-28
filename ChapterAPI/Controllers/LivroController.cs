using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChapterAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ChapterAPI.Controllers
{
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
    }
}

