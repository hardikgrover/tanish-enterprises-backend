using System.Collections.Generic;
using System.Threading.Tasks;
using TanishEnterprisesBackend.Models;

namespace TanishEnterprisesBackend.Repositories
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(int id);
        Task AddAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(Product product);
    }
}
