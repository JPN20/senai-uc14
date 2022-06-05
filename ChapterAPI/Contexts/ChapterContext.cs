using System;
using ChapterAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ChapterAPI.Contexts
{
	public class ChapterContext : DbContext
	{
		public ChapterContext()
		{
		}

        public ChapterContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=192.168.1.250;Database=Chapter;User Id=van;Password=******;");
            }
        }

        public DbSet<Livro> Livros { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}

