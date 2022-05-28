using System;
using ChapterAPI.Contexts;
using ChapterAPI.Models;

namespace ChapterAPI.Repositories
{
	public class LivroRepository
	{
		private readonly ChapterContext _context;	

		public LivroRepository(ChapterContext context)
		{
			_context = context;
		}

		public List<Livro> Listar()
        {
			return _context.Livros.ToList();
        }
	}
}

