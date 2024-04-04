﻿namespace DifferentTypesOfActionResultsInAspNetCore.Models
{
    public class Product
    {
        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string ProductCategory { get; set; }
        public bool IsInStock { get; set; }

    }
}
