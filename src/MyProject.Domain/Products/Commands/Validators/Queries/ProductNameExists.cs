using Kledex.Queries;

namespace MyProject.Domain.Products.Commands.Validators.Queries
{
    public class ProductNameExists : Query<bool>
    {
        public string ProductName { get; set; }
    }
}
