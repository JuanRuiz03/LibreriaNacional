using BibliotecaNacional.Models;

namespace BibliotecaNacional.Interfaces
{
    // Define la "promesa o contrato" de lo que puede hacer nuestro repositorio, lo podemos implementar luego
    public interface IEditorialRepository
    {
        Task<IEnumerable<Editorial>> GetAllAsync(); // Usamos async para mejoras en performance
        Task<Editorial> GetByIdAsync(int id);
        Task AddAsync(Editorial editorial);
        Task UpdateAsync(Editorial editorial);
        Task DeleteAsync(int id);
        Task<bool> SaveChangesAsync();
    }
}