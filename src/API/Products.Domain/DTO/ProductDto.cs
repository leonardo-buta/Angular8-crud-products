using System;

namespace Products.Domain.DTO
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastModified { get; set; }
        public bool Active { get; set; }
    }
}
