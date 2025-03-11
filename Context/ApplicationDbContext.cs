using Library.Models.Domain;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Library.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Fotografia> Fotografias { get; set; }
        public DbSet<Author> Authors { get; set; }
		public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Galeria> Galerias { get; set; }
    }
}
