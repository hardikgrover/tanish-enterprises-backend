using System.Collections.Generic;
using System.Threading.Tasks;
using TanishEnterprisesBackend.Models;

namespace TanishEnterprisesBackend.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private List<Product> _products;


        public ProductRepository()
        {
            _products = new List<Product> { new Product { Id = 1, Description = "Product 1", Price = 19.99m, CreatedAt = DateTime.Now } };
        }

        public Task<List<Product>> GetAllAsync()
        {
            return Task.FromResult(_products);
        }

        public Task<Product> GetByIdAsync(int id)
        {
            return Task.FromResult(_products.Find(p => p.Id == id));
        }

        public Task AddAsync(Product product)
        {
            _products.Add(product);
            return Task.CompletedTask;
        }

        public Task UpdateAsync(Product product)
        {
            var index = _products.FindIndex(p => p.Id == product.Id);
            if (index > -1)
            {
                _products[index] = product;
            }
            return Task.CompletedTask;
        }

        public Task DeleteAsync(Product product)
        {
            _products.Remove(product);
            return Task.CompletedTask;
        }
    }
}
