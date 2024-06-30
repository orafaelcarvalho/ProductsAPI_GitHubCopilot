using AutoMapper;
using ProductsAPI_GitHubCopilot.Domain.Exceptions;
using ProductsAPI_GitHubCopilot.Domain.Interfaces;
using ProductsAPI_GitHubCopilot.Domain.Models;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public ProductService(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<ProductDTO> AddProductAsync(ProductCreateModel model)
    {
        var product = _mapper.Map<Product>(model);
        await _productRepository.AddAsync(product);
        return _mapper.Map<ProductDTO>(product);
    }

    public async Task<ProductDTO> UpdateProductAsync(ProductUpdateModel model)
    {
        var product = await _productRepository.GetByIdAsync(model.Id);
        if (product == null)
        {
            throw new RecordNotFoundException("Product not found", $"Product with Id {model.Id} does not exist.");
        }
        var teste = _mapper.Map(model, product);
        await _productRepository.UpdateAsync(product);
        return _mapper.Map<ProductDTO>(product);
    }

    public async Task<bool> DeleteProductAsync(int id)
    {
        var product = await _productRepository.GetByIdAsync(id);
        if (product == null)
        {
            throw new RecordNotFoundException("Product not found", $"Product with Id {id} does not exist.");
        }
        await _productRepository.DeleteAsync(product.Id);
        return true;
    }

    public async Task<ProductDTO> GetProductByIdAsync(int id)
    {
        var product = await _productRepository.GetByIdAsync(id);
        if (product == null)
        {
            throw new RecordNotFoundException("Product not found", $"Product with Id {id} does not exist.");
        }
        return _mapper.Map<ProductDTO>(product);
    }

    public async Task<IEnumerable<ProductDTO>> GetAllProductsAsync()
    {
        var products = await _productRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<ProductDTO>>(products);
    }
}
