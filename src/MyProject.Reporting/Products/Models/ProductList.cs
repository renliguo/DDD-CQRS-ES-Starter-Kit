using System.Collections.Generic;

namespace MyProject.Reporting.Products.Models
{
    public class ProductList
    {
        public IEnumerable<ProductListView> Products { get; set; }

        // Add other stuff like pagination etc...
    }
}
