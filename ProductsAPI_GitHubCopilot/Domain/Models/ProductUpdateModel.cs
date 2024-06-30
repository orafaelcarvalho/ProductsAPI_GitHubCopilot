namespace ProductsAPI_GitHubCopilot.Domain.Models
{
    public class ProductUpdateModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public ProductStatus Status { get; set; }
        public DateTime ManufactureDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int SupplierId { get; set; }
    }
}