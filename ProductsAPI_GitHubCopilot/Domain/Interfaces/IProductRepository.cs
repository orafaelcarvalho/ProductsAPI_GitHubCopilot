using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProductsAPI_GitHubCopilot.Domain.Entities;

namespace ProductsAPI_GitHubCopilot.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> GetByIdAsync(Guid id);
        Task<IEnumerable<Product>> GetAllAsync();
        Task AddAsync(Product product);
        Task UpdateAsync(Product product);
    }
}
