using ProductsAPI_GitHubCopilot.Domain.Models;

public interface IProductService
{
    Task<ProductDTO> AddProductAsync(ProductCreateModel model);
    Task<ProductDTO> UpdateProductAsync(ProductUpdateModel model);
    Task<bool> DeleteProductAsync(int id);
    Task<ProductDTO> GetProductByIdAsync(int id);
    Task<IEnumerable<ProductDTO>> GetAllProductsAsync();
}