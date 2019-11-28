using Kledex.Queries;
using MyProject.Reporting.Products.Models;
using System;

namespace MyProject.Reporting.Products.Queries
{
    public class GetProductView : Query<ProductView>
    {
        public Guid ProductId { get; set; }
    }
}
