using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TanishEnterprisesBackend.Models;
using TanishEnterprisesBackend.Services;

namespace TanishEnterprisesBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetAllAsync()
        {
            var products = await _productService.GetAllAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetByIdAsync(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<Product>> AddAsync(Product product)
        {
            await _productService.AddAsync(product);
            return Ok("product added");
            // return CreatedAtAction(nameof(GetByIdAsync), new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            var productExists = await _productService.GetByIdAsync(id);
            if (productExists == null)
            {
                return NotFound();
            }

            await _productService.UpdateAsync(product);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var productExists = await _productService.GetByIdAsync(id);
            if (productExists == null)
            {
                return NotFound();
            }

            await _productService.DeleteAsync(productExists);
            return NoContent();
        }
    }
}

