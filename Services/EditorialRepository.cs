using BibliotecaNacional.Data;
using BibliotecaNacional.Interfaces;
using BibliotecaNacional.Models;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaNacional.Services
{
    public class EditorialRepository : IEditorialRepository
    {
        private readonly AppDbContext _context;

        // Inyección de Dependencias del Contexto
        public EditorialRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Editorial>> GetAllAsync()
        {
            // Ejecuta la consulta a la BD y devuelve la lista
            return await _context.Editoriales.ToListAsync(); 
        }

        public async Task<Editorial> GetByIdAsync(int id)
        {
            return await _context.Editoriales.FindAsync(id);
        }

        public async Task AddAsync(Editorial editorial)
        {
            await _context.Editoriales.AddAsync(editorial);
            await SaveChangesAsync();
        }
        
        public async Task UpdateAsync(Editorial editorial)
        {
            _context.Editoriales.Update(editorial);
            await SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var editorial = await GetByIdAsync(id);
            if (editorial != null)
            {
                _context.Editoriales.Remove(editorial);
                await SaveChangesAsync();
            }
        }

        public async Task<bool> SaveChangesAsync()
        {
            // Mejoras de Performance: Devuelve true si al menos un cambio fue guardado
            return await _context.SaveChangesAsync() > 0;
        }
    }
}