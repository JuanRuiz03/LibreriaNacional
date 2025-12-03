using BibliotecaNacional.Models;

namespace BibliotecaNacional.Interfaces
{
    public interface ILibroRepository
    {
        // El método GetAll debe incluir la editorial relacionada (JOIN)
        Task<IEnumerable<Libro>> GetAllAsync();
        Task<Libro> GetByIdAsync(long isbn);
        Task AddAsync(Libro libro);
        Task UpdateAsync(Libro libro);
        Task DeleteAsync(long isbn);
        Task<bool> SaveChangesAsync();
    }
}