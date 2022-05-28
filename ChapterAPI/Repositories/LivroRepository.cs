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

		public Livro BuscarPorId(int id)
        {
			return _context.Livros.Find(id);
        }

		public void Cadastrar(Livro livro)
        {
			_context.Livros.Add(livro);
			_context.SaveChanges();
        }

		public void Atualizar(int id, Livro livro)
        {
			var livroBuscado = _context.Livros.Find(id);

			if (livroBuscado != null)
            {
				livroBuscado.Id = id;
				livroBuscado.Titulo = livro.Titulo;
				livroBuscado.QuantidadePaginas = livro.QuantidadePaginas;
				livroBuscado.Disponivel = livro.Disponivel;

				_context.Livros.Update(livroBuscado);
				_context.SaveChanges();
            }
        }

		public void Excluir(int id)
        {
			var livro = _context.Livros.Find(id);

			if (livro != null)
            {
				_context.Livros.Remove(livro);
				_context.SaveChanges();
            }
        }
	}
}

