using Kledex.Domain;

namespace MyProject.Domain.Models.Products.Commands
{
    public class UpdateProductName : DomainCommand<Product>
    {
        public string Name { get; set; }
    }
}
