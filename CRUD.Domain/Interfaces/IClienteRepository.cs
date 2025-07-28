using CRUD.Domain.Entities;

namespace CRUD.Domain.Interfaces
{
    public interface IClienteRepository
    {
        Task<Cliente?> GetByIdAsync(int id);
        Task<Cliente?> GetByDocumentAsync(string documento);
        Task<IEnumerable<Cliente>> GetAllAsync();
        Task InsertAsync(Cliente cliente);
        Task UpdateAsync(Cliente cliente);
        Task DeleteAsync(int id);
    }
}