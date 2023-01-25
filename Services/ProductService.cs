using System.Collections.Generic;
using System.Threading.Tasks;
using tanish_enterprises_backend.Models;
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

        public async Task<ServiceResponse<List<Product>>> GetAllAsync()
        {
            var serviceResponse = new ServiceResponse<List<Product>>();
            var products = await _productRepository.GetAllAsync();
            serviceResponse.Data = products.ToList();
            return serviceResponse;
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
