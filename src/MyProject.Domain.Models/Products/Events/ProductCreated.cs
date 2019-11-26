using Kledex.Domain;

namespace MyProject.Domain.Models.Products.Events
{
    public class ProductCreated : DomainEvent
    {
        public string Name { get; set; }
        public ProductStatus Status { get; set; }
    }
}
