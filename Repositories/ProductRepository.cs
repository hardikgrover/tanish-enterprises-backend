using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using tanish_enterprises_backend.Data;
using TanishEnterprisesBackend.Models;

namespace TanishEnterprisesBackend.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private List<Product> _products = new List<Product>
    {
        new Product { Id = 1, Name = "Product 1", Description = "Description of Product 1", Price = 10.99m },
        new Product { Id = 2, Name = "Product 2", Description = "Description of Product 2", Price = 12.99m },
        new Product { Id = 3, Name = "Product 3", Description = "Description of Product 3", Price = 14.99m }
    };

    private readonly TanishEnterprisesDbContext _context;


        public ProductRepository(TanishEnterprisesDbContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetAllAsync()
        {
            var products = await _context.Products.ToListAsync();

            return products;
        }

        public Task<Product> GetByIdAsync(int id)
        {
            return Task.FromResult(_products.Find(p => p.Id == id));
        }

        public async Task<bool> AddAsync(Product product)
        {
            await _context.Products.AddAsync(product);
        var created = await _context.SaveChangesAsync();
              return created > 0;
            // _products.Add(product);
            // return Task.CompletedTask;
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
