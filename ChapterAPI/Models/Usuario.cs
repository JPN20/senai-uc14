using System;

namespace ChapterAPI.Models
{
	public class Usuario
	{
		public Usuario()
		{
			Perfil = Perfil.Usuario;
		}

		public int Id { get; set; }

		public string Email { get; set; }

		public string Senha { get; set; }

		public Perfil Perfil { get; set; }
	}
}

