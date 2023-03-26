using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int TotalQuantity { get; set; }
        public decimal TotalPrice { get; set; }

        public int UserId { get; set; }
        public User? User { get; set; }
        public ICollection<OrderProduct>? OrderProducts { get; set; }
    }
}
