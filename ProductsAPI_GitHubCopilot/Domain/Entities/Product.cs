using System;
using ProductsAPI_GitHubCopilot.Domain.Enums;

namespace ProductsAPI_GitHubCopilot.Domain.Entities
{
    public class Product
    {
        public Guid Id { get; private set; }
        public string Description { get; private set; }
        public ProductStatus Status { get; private set; }
        public DateTime ManufacturingDate { get; private set; }
        public DateTime ExpirationDate { get; private set; }
        public string SupplierCode { get; private set; }

        public Product(string description, ProductStatus status, DateTime manufacturingDate, DateTime expirationDate, string supplierCode)
        {
            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentException("Description cannot be empty or null.", nameof(description));

            if (string.IsNullOrWhiteSpace(supplierCode))
                throw new ArgumentException("SupplierCode cannot be empty or null.", nameof(supplierCode));

            if (manufacturingDate >= expirationDate)
                throw new ArgumentException("ManufacturingDate must be earlier than ExpirationDate.");

            Id = Guid.NewGuid();
            Description = description;
            Status = status;
            ManufacturingDate = manufacturingDate;
            ExpirationDate = expirationDate;
            SupplierCode = supplierCode;
        }

        public void MarkAsDeleted()
        {
            Status = ProductStatus.Deleted;
        }
    }
}
