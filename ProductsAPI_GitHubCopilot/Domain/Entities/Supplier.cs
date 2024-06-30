using ProductsAPI_GitHubCopilot.Domain.Entities;
using ProductsAPI_GitHubCopilot.Domain.Models;

public class Supplier : BaseEntity
{
    //
    public string Description { get; set; }
    public string Cnpj { get; set; }
    public Supplier()
    {
        
    }
    public Supplier(SupplierCreateModel model)
    {
        Description = model.Description;
        Cnpj = model.Cnpj;
    }

    public void Update(SupplierUpdateModel model)
    {
        Description = model.Description;
        Cnpj = model.Cnpj;
    }
}