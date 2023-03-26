using ECommerce.Message;
using System.Collections.Generic;

namespace ECommerce.Models
{
    public class Product : ISendable
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Make { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Composition { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;

        public int CategoryId { get; set; }
        public Category? Category { get; set; } 

        public ICollection<OrderProduct>? OrderProducts { get; set; }
        public ICollection<ProductAttribute>? ProductAttributes { get; set; }
    }
}
