﻿using Kledex.Domain;

namespace MyProject.Domain.Products.Commands
{
    public class UpdateProductDetails : DomainCommand<Product>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
