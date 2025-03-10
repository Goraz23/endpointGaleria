using Library.Models.Domain;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Library.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Author> Authors { get; set; }
		public DbSet<Book> Books { get; set; }
        public DbSet<Editorial> Editorials { get; set; }
    }
}
