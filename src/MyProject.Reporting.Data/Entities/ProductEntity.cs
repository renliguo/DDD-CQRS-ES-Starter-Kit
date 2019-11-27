using MyProject.Domain.Models.Products;
using System;

namespace MyProject.Reporting.Data.Entities
{
    public class ProductEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public ProductStatus Status { get; set; }
    }
}
