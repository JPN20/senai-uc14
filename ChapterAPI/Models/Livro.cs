using System;
namespace ChapterAPI.Models
{
	public class Livro
	{
		public Livro()
		{
		}

		public int Id { get; set; }

		public string Titulo { get; set; }

		public int QuantidadePaginas { get; set; }

		public bool Disponivel { get; set; }
	}
}

