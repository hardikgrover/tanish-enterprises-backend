using System.Collections.Generic;
using System.Threading.Tasks;
using TanishEnterprisesBackend.Models;
using TanishEnterprisesBackend.Repositories;

namespace TanishEnterprisesBackend.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _productRepository.GetAllAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _productRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(Product product)
        {
            await _productRepository.AddAsync(product);
        }

        public async Task UpdateAsync(Product product)
        {
            await _productRepository.UpdateAsync(product);
        }

        public async Task DeleteAsync(Product product)
        {
            await _productRepository.DeleteAsync(product);
        }
    }
}
