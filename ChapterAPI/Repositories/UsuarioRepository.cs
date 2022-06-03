using System;
using ChapterAPI.Contexts;
using ChapterAPI.Models;

namespace ChapterAPI.Repositories
{
	public class UsuarioRepository
	{
		private readonly ChapterContext _context;

		public UsuarioRepository(ChapterContext context)
		{
			_context = context;
		}

		public List<Usuario> Listar()
		{
			return _context.Usuarios.ToList();
		}

		public Usuario BuscarPorId(int id)
		{
			return _context.Usuarios.Find(id);
		}

		public void Cadastrar(Usuario usuario)
		{
			_context.Usuarios.Add(usuario);
			_context.SaveChanges();
		}

		public void Atualizar(int id, Usuario usuario)
		{
			var usuarioBuscado = _context.Usuarios.Find(id);

			if (usuarioBuscado != null)
			{
				usuarioBuscado.Id = id;
				usuarioBuscado.Email = usuario.Email;
				usuarioBuscado.Senha = usuario.Senha;
				usuarioBuscado.Perfil = usuario.Perfil;

				_context.Usuarios.Update(usuarioBuscado);
				_context.SaveChanges();
			}
		}

		public void Excluir(int id)
		{
			var usuario = _context.Usuarios.Find(id);

			if (usuario != null)
			{
				_context.Usuarios.Remove(usuario);
				_context.SaveChanges();
			}
		}

		public Usuario Entrar(string email, string senha)
		{
			return _context.Usuarios.FirstOrDefault(u => u.Email.Equals(email) && u.Senha.Equals(senha));
		}
	}
}

