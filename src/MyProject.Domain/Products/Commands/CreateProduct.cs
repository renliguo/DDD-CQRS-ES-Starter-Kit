using Kledex.Domain;

namespace MyProject.Domain.Products.Commands
{
    public class CreateProduct : DomainCommand<Product>
    {
        public CreateProduct()
        {
            Validate = true;
        }

        public string Name { get; set; }
    }
}
