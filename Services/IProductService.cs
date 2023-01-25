using System.Collections.Generic;
using System.Threading.Tasks;
using tanish_enterprises_backend.Models;
using TanishEnterprisesBackend.Models;

namespace TanishEnterprisesBackend.Services
{
    public interface IProductService
    {
        Task<ServiceResponse<List<Product>>> GetAllAsync();
        Task<Product> GetByIdAsync(int id);
        Task AddAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(Product product);
    }
}
