using BibliotecaNacional.Data;
using BibliotecaNacional.Interfaces;
using BibliotecaNacional.Models;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaNacional.Services
{
    public class LibroRepository : ILibroRepository
    {
        private readonly AppDbContext _context;

        public LibroRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Libro>> GetAllAsync()
        {
            
            return await _context.Libros.Include(l => l.Editorial).ToListAsync();
        }

        public async Task<Libro> GetByIdAsync(long isbn)
        {
            // También incluimos la Editorial al buscar por ID
            return await _context.Libros
                .Include(l => l.Editorial)
                .FirstOrDefaultAsync(l => l.ISBN == isbn);
        }

        public async Task AddAsync(Libro libro)
        {
            await _context.Libros.AddAsync(libro);
            await SaveChangesAsync();
        }

        public async Task UpdateAsync(Libro libro)
        {
            _context.Libros.Update(libro);
            await SaveChangesAsync();
        }

        public async Task DeleteAsync(long isbn)
        {
            var libro = await GetByIdAsync(isbn);
            if (libro != null)
            {
                _context.Libros.Remove(libro);
                await SaveChangesAsync();
            }
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}