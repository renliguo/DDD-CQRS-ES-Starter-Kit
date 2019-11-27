﻿using MyProject.Domain.Models.Products;
using System;

namespace MyProject.Reporting.Models
{
    public class ProductView
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal ProductPrice { get; set; }
        public ProductStatus ProductStatus { get; set; }
    }
}
