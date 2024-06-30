namespace ProductsAPI_GitHubCopilot.Domain.Models
{
    public class SupplierUpdateModel
    {
        public int Id { get; set; } // Incluído para identificar unicamente o registro a ser atualizado
        public string Description { get; set; }
        public string Cnpj { get; set; }
    }
}