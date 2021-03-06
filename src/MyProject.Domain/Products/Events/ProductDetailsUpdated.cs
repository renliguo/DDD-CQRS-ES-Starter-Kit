﻿using Kledex.Domain;

namespace MyProject.Domain.Products.Events
{
    public class ProductDetailsUpdated : DomainEvent
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
