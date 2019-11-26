using Kledex.Domain;

namespace MyProject.Domain.Models.Products.Commands
{
    public class CreateProduct : DomainCommand<Product>
    {
        public string Name { get; set; }
    }
}
