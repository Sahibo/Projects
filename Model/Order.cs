using System;
using System.Collections.Generic;

namespace ECommerceAdmin.Model;

public partial class Order
{
    public int Id { get; set; }

    public DateTime Date { get; set; }

    public int TotalQuantity { get; set; }

    public decimal TotalPrice { get; set; }

    public int UserId { get; set; }

    public virtual ICollection<OrderProduct> OrderProducts { get; } = new List<OrderProduct>();

    public virtual User User { get; set; } = null!;
}
