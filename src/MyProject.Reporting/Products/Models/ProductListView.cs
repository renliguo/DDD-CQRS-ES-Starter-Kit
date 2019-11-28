using MyProject.Domain.Products;
using System;

namespace MyProject.Reporting.Products.Models
{

    public class ProductListView
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public ProductStatus ProductStatus { get; set; }
    }
}
