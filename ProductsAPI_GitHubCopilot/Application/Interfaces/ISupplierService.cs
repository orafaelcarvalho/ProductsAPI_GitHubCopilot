using ProductsAPI_GitHubCopilot.Domain.Models;

public interface ISupplierService
{
    Task<SupplierDTO> AddSupplierAsync(SupplierCreateModel model);
    Task<SupplierDTO> UpdateSupplierAsync(SupplierUpdateModel model);
    Task<bool> DeleteSupplierAsync(int id);
    Task<SupplierDTO> GetSupplierByIdAsync(int id);
    Task<IEnumerable<SupplierDTO>> GetAllSuppliersAsync();
}