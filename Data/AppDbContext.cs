using Microsoft.EntityFrameworkCore;
using BibliotecaNacional.Models;

namespace BibliotecaNacional.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    // DbSets que mapean a nuestras tablas
        public DbSet<Editorial> Editoriales { get; set; }
        public DbSet<Libro> Libros { get; set; }

}