using ProductsAPI_GitHubCopilot.Domain.Entities;
using ProductsAPI_GitHubCopilot.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;

public class Product : BaseEntity
{
    public string Description { get; set; }
    public ProductStatus Status { get; set; }
    public DateTime ManufactureDate { get; set; }
    public DateTime ExpirationDate { get; set; }
    [ForeignKey("Supplier")]
    public int SupplierId { get; set; }
    public Supplier Supplier { get; set; }
    public Product()
    {
        
    }
    public Product(ProductCreateModel model)
    {
        Description = model.Description;
        Status = model.Status;
        ManufactureDate = model.ManufactureDate;
        ExpirationDate = model.ExpirationDate;
        SupplierId = model.SupplierId;        
    }

    public Product(ProductUpdateModel model)
    {
        Description = model.Description;
        Status = model.Status;
        ManufactureDate = model.ManufactureDate;
        ExpirationDate = model.ExpirationDate;
        SupplierId = model.SupplierId;
    }
}