using AutoMapper;
using ProductsAPI_GitHubCopilot.Domain.Exceptions;
using ProductsAPI_GitHubCopilot.Domain.Interfaces;
using ProductsAPI_GitHubCopilot.Domain.Models;
using System.Reflection;

public class SupplierService : ISupplierService
{
    private readonly ISupplierRepository _supplierRepository;
    private readonly IMapper _mapper;

    public SupplierService(ISupplierRepository supplierRepository, IMapper mapper)
    {
        _supplierRepository = supplierRepository;
        _mapper = mapper;
    }

    public async Task<SupplierDTO> AddSupplierAsync(SupplierCreateModel model)
    {
        Supplier supplier = new Supplier(model);        
        await _supplierRepository.AddAsync(supplier);
        return _mapper.Map<SupplierDTO>(supplier);
    }

    public async Task<SupplierDTO> UpdateSupplierAsync(SupplierUpdateModel model)
    {
        var supplier = await _supplierRepository.GetByIdAsync(model.Id);
        if (supplier == null)
        {
            throw new RecordNotFoundException("Supplier not found", $"Supplier with Id {model.Id} does not exist.");
        }
        var teste = _mapper.Map(model, supplier);
        await _supplierRepository.UpdateAsync(supplier);
        return _mapper.Map<SupplierDTO>(supplier);
    }

    public async Task<bool> DeleteSupplierAsync(int id)
    {
        var supplier = await _supplierRepository.GetByIdAsync(id);
        if (supplier == null)
        {
            throw new RecordNotFoundException("Supplier not found", $"Supplier with Id {id} does not exist.");
        }
        await _supplierRepository.DeleteAsync(supplier.Id);
        return true;
    }

    public async Task<SupplierDTO> GetSupplierByIdAsync(int id)
    {
        var supplier = await _supplierRepository.GetByIdAsync(id);
        if (supplier == null)
        {
            throw new RecordNotFoundException("Supplier not found", $"Supplier with Id {id} does not exist.");
        }
        return _mapper.Map<SupplierDTO>(supplier);
    }

    public async Task<IEnumerable<SupplierDTO>> GetAllSuppliersAsync()
    {
        var suppliers = await _supplierRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<SupplierDTO>>(suppliers);
    }
}
