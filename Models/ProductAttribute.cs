using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Models
{
    public class ProductAttribute
    {
        public int Id { get; set; }
        public string Size { get; set; } = null!;
        public int Discount { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public int ProductId { get; set; }
        public Product? Product { get; set; }
    }
}
