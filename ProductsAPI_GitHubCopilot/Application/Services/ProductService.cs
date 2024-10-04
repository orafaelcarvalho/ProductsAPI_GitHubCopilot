using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProductsAPI_GitHubCopilot.Application.Interfaces;
using ProductsAPI_GitHubCopilot.Domain.Entities;
using ProductsAPI_GitHubCopilot.Domain.Interfaces;

namespace ProductsAPI_GitHubCopilot.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> GetProductByIdAsync(Guid id)
        {
            return await _productRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _productRepository.GetAllAsync();
        }

        public async Task CreateProductAsync(Product product)
        {
            await _productRepository.AddAsync(product);
        }

        public async Task UpdateProductAsync(Product product)
        {
            await _productRepository.UpdateAsync(product);
        }

        public async Task DeleteProductAsync(Guid id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product != null)
            {
                product.MarkAsDeleted();
                await _productRepository.UpdateAsync(product);
            }
        }
    }
}

