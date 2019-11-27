using Kledex.Queries;
using System;

namespace MyProject.Reporting.Models.Products.Queries
{
    public class GetProductView : Query<ProductView>
    {
        public Guid ProductId { get; set; }
    }
}
