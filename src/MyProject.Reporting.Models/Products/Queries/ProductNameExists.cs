using Kledex.Queries;

namespace MyProject.Reporting.Models.Products.Queries
{
    public class ProductNameExists : Query<bool>
    {
        public string ProductName { get; set; }
    }
}
