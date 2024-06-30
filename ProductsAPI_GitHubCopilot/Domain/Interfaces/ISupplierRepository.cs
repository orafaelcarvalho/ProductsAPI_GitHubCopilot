namespace ProductsAPI_GitHubCopilot.Domain.Interfaces
{
    public interface ISupplierRepository
    {
        Task AddAsync(Supplier supplier);
        Task UpdateAsync(Supplier supplier);
        Task DeleteAsync(int id);
        Task<Supplier> GetByIdAsync(int id);
        Task<IEnumerable<Supplier>> GetAllAsync();
    }
}