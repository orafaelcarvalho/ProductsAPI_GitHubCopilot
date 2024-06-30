public class ProductDTO
{
    public int Id { get; set; }
    public string Description { get; set; }
    public ProductStatus Status { get; set; }
    public DateTime ManufactureDate { get; set; }
    public DateTime ExpirationDate { get; set; }
    public string SupplierCode { get; set; }
    // Informações do fornecedor podem ser incluídas como um DTO separado se necessário
    public SupplierDTO Supplier { get; set; }
}