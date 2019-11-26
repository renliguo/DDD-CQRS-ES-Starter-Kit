using Kledex.Domain;

namespace MyProject.Domain.Models.Products.Events
{
    public class ProductNameUpdated : DomainEvent
    {
        public string Name { get; set; }
    }
}
